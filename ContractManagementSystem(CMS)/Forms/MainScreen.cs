using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContractManagementSystem_CMS_.Extensions;
using ContractManagementSystem_CMS_.Forms;
using ContractManagementSystem_CMS_.Models;
using ContractManagementSystem_CMS_.Services;

namespace ContractManagementSystem_CMS_
{
    public partial class MainScreen : Form
    {
        private readonly DatabaseService _dbService;
        private readonly FileService _fileService;
        private readonly AnalysisEngine _analysisEngine;
        private readonly ExportService _exportService;
        private readonly AIService _aiService;
        private readonly SearchService _searchService;
        private readonly ExtractionService _extractionService;
        private readonly ContractService _contractService;
        private readonly DateReminderService _dateService;

        private List<Rules> _activeRules = new List<Rules>();
        private string _selectedFilePath = "";
        private AnalysisResult? _lastAnalysisResult = null;
        private AIService.AIAnalysisResult? _lastAIResult = null;
        private List<SearchResult> _lastSearchResults = new List<SearchResult>();
        private int _currentContractId = 0;

        public MainScreen()
        {
            InitializeComponent();
            _dbService = new DatabaseService();
            _fileService = new FileService();
            _analysisEngine = new AnalysisEngine();
            _exportService = new ExportService();
            _aiService = new AIService();
            _searchService = new SearchService();
            _extractionService = new ExtractionService();
            _contractService = new ContractService();
            _dateService = new DateReminderService();

            ApplyThemeToControls();
            InitializeEventHandlers();
            SetupTabControlTheme();
            InitializeSearchControls();
        }

        private void InitializeSearchControls()
        {
            cmbSearchType.Items.AddRange(new object[] { "Anahtar Kelime", "Doğal Dil" });
            cmbSearchType.SelectedIndex = 0;
        }

        private void SetupTabControlTheme()
        {
            tabResults.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabResults.Padding = new Point(12, 4);
            tabResults.DrawItem += TabResults_DrawItem;
        }

        private void TabResults_DrawItem(object? sender, DrawItemEventArgs e)
        {
            var tc = sender as TabControl;
            if (tc == null) return;

            bool isSelected = (e.Index == tc.SelectedIndex);

            Color bgColor = isSelected ? UIStyleHelper.AccentBlue : UIStyleHelper.AccentBg;
            Color textColor = isSelected ? Color.White : UIStyleHelper.SecondaryText;

            using (SolidBrush bgBrush = new SolidBrush(bgColor))
            {
                e.Graphics.FillRectangle(bgBrush, e.Bounds);
            }

            string tabText = tc.TabPages[e.Index].Text;
            using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                using (SolidBrush textBrush = new SolidBrush(textColor))
                {
                    using (Font font = new Font("Segoe UI", 9f, isSelected ? FontStyle.Bold : FontStyle.Regular))
                    {
                        e.Graphics.DrawString(tabText, font, textBrush, e.Bounds, sf);
                    }
                }
            }
        }

        private void ApplyThemeToControls()
        {
            UIStyleHelper.ApplyButtonTheme(btnManageRules, UIStyleHelper.AccentBg, UIStyleHelper.PrimaryText);
            UIStyleHelper.ApplyButtonTheme(btnSearch, UIStyleHelper.AccentBlue, Color.White);
            UIStyleHelper.ApplyButtonTheme(btnClearSearch, UIStyleHelper.AccentBg, UIStyleHelper.PrimaryText);
            UIStyleHelper.ApplyModernTableTheme(dgvSearchResults);
            UIStyleHelper.ApplyModernTableTheme(dataGridViewResultScreen);
        }

        private void InitializeEventHandlers()
        {
            richTextBoxViewContract.EnableDragDrop(filePath =>
            {
                _selectedFilePath = filePath;
                richTextBoxViewContract.ClearHighlights();
                dataGridViewResultScreen.Rows.Clear();
                dgvSearchResults.Rows.Clear();
                _lastAnalysisResult = null;
                _lastAIResult = null;
                rtbAIResults.Clear();
                rtbSummary.Clear();
                UIStyleHelper.ApplyModernTableTheme(dataGridViewResultScreen);
                UIStyleHelper.ApplyModernTableTheme(dgvSearchResults);
            });

            this.Load += MainScreen_Load;
        }

        private void txtSearchQuery_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnSearch.PerformClick();
            }
        }

        private async void btnSearch_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(richTextBoxViewContract.Text))
            {
                MessageBox.Show("Lütfen bir sözleşme yükleyin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSearchQuery.Text))
            {
                MessageBox.Show("Lütfen bir arama sorgusu girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string searchType = cmbSearchType.SelectedItem?.ToString() ?? "Anahtar Kelime";
            string query = txtSearchQuery.Text.Trim();

            try
            {
                lblSearchStatus.Text = "Aranıyor...";
                dgvSearchResults.Rows.Clear();
                _lastSearchResults.Clear();

                List<SearchResult> results;

                if (searchType == "Doğal Dil")
                {
                    btnSearch.Enabled = false;
                    lblSearchStatus.Text = "Ollama ile aranıyor...";
                    string aiResponse = await _aiService.SearchInContractAsync(richTextBoxViewContract.Text, query);

                    results = new List<SearchResult>
                    {
                        new SearchResult
                        {
                            Index = 1,
                            MatchedText = query,
                            Context = aiResponse,
                            Position = -1,
                            LineNumber = -1,
                            SearchType = "Doğal Dil"
                        }
                    };
                }
                else
                {
                    results = _searchService.SearchByKeyphrase(richTextBoxViewContract.Text, query);
                }

                _lastSearchResults = results;

                foreach (var result in results)
                {
                    dgvSearchResults.Rows.Add(result.Index, result.MatchedText, result.SearchType, result.LineNumber, result.Context);
                }

                lblSearchStatus.Text = $"{results.Count} sonuç";

                if (results.Count > 0 && searchType != "Doğal Dil")
                {
                    richTextBoxViewContract.ClearHighlights();
                    foreach (var result in results)
                    {
                        if (result.Position >= 0)
                        {
                            richTextBoxViewContract.HighlightWordAtPosition(result.Position, result.MatchedText.Length, UIStyleHelper.AccentBlue);
                        }
                    }
                }

                tabResults.SelectedTab = tabPageSearch;
            }
            catch (Exception ex)
            {
                lblSearchStatus.Text = "Hata: " + ex.Message;
            }
            finally
            {
                btnSearch.Enabled = true;
            }
        }

        private void btnClearSearch_Click(object? sender, EventArgs e)
        {
            txtSearchQuery.Clear();
            dgvSearchResults.Rows.Clear();
            _lastSearchResults.Clear();
            lblSearchStatus.Text = "";
            richTextBoxViewContract.ClearHighlights();
        }

        private void dgvSearchResults_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _lastSearchResults.Count) return;

            var result = _lastSearchResults[e.RowIndex];
            if (result.Position >= 0 && result.SearchType != "Doğal Dil")
            {
                richTextBoxViewContract.Select(result.Position, result.MatchedText.Length);
                richTextBoxViewContract.ScrollToCaret();
                richTextBoxViewContract.Focus();
            }
        }

        private async Task InitializeAIOperationAsync()
        {
            try
            {
                bool connected = await _aiService.CheckConnectionAsync();
                if (connected)
                {
                    lblAIStatus.Text = "Ollama: Bağlı";
                    lblAIStatus.ForeColor = UIStyleHelper.AccentGreen;
                }
                else
                {
                    lblAIStatus.Text = "Ollama: Bağlantı Yok";
                    lblAIStatus.ForeColor = UIStyleHelper.AccentRed;
                }
            }
            catch
            {
                lblAIStatus.Text = "Ollama: Bağlantı Hatası";
                lblAIStatus.ForeColor = UIStyleHelper.AccentRed;
            }
        }

        private void MainScreen_Load(object? sender, EventArgs e)
        {
            LoadComboBox();
            _ = InitializeAIOperationAsync();
            CheckUpcomingDates();
        }

        private void CheckUpcomingDates()
        {
            try
            {
                var upcoming = _dateService.GetUpcomingDates(7);
                if (upcoming.Count > 0)
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        using (var popup = new UpcomingDatesForm(upcoming))
                        {
                            popup.ShowDialog(this);
                        }
                    }));
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine($"[MainScreen] Yaklaşan tarih kontrolü hatası: {ex.Message}");
            }
        }

        private void btnUpcomingDates_Click(object? sender, EventArgs e)
        {
            using (var form = new DateManagementForm())
            {
                form.ShowDialog(this);
            }
        }

        private void LoadComboBox()
        {
            try
            {
                comboboxContractType.SelectedIndexChanged -= comboboxContractType_SelectedIndexChanged;
                var allTypes = _dbService.GetAllTypes();
                if (allTypes?.Count > 0)
                {
                    comboboxContractType.DataSource = allTypes;
                    comboboxContractType.DisplayMember = "TypeName";
                    comboboxContractType.ValueMember = "Id";
                    comboboxContractType.SelectedIndex = -1;
                }
                comboboxContractType.SelectedIndexChanged += comboboxContractType_SelectedIndexChanged;
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
        }

        private void comboboxContractType_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (comboboxContractType.SelectedValue != null && int.TryParse(comboboxContractType.SelectedValue.ToString(), out int id))
                _activeRules = _dbService.GetRulesByTypeId(id);
        }

        private async void btnAnalyze_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(richTextBoxViewContract.Text))
            {
                MessageBox.Show("Lütfen bir sözleşme yükleyin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (comboboxContractType.SelectedValue == null || !int.TryParse(comboboxContractType.SelectedValue.ToString(), out int selectedId))
            {
                MessageBox.Show("Lütfen bir sözleşme türü seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                btnAnalyze.Enabled = false;
                btnAnalyze.Text = "Analiz ediliyor...";
                progressAI.Visible = true;
                progressAI.Style = ProgressBarStyle.Marquee;

                richTextBoxViewContract.ClearHighlights();
                dataGridViewResultScreen.Rows.Clear();
                rtbAIResults.Clear();
                rtbSummary.Clear();
                rtbExtractions.Clear();

                // 1. Kural Analizi
                lblAIStatus.Text = "Kural analizi çalıştırılıyor...";
                lblAIStatus.ForeColor = UIStyleHelper.AccentBlue;

                var localResult = _analysisEngine.PerformAnalysis(richTextBoxViewContract.Text, selectedId);
                if (localResult == null)
                    localResult = new AnalysisResult { TotalScore = 0, Details = new List<AnalysisDetail>() };

                foreach (var detail in localResult.Details)
                {
                    dataGridViewResultScreen.Rows.Add(detail.RuleDescription, detail.Status);
                    if (detail.BoyaRengi != Color.Empty && !string.IsNullOrEmpty(detail.Pattern))
                        richTextBoxViewContract.HighlightPattern(detail.Pattern, detail.BoyaRengi);
                }

                _lastAnalysisResult = localResult;
                UIStyleHelper.ApplyModernTableTheme(dataGridViewResultScreen);
                tabResults.SelectedTab = tabPageRules;

                // 2. AI Analiz
                lblAIStatus.Text = "Ollama: AI analiz ediliyor...";
                lblAIStatus.ForeColor = UIStyleHelper.AccentPurple;

                string contractType = comboboxContractType.Text;
                var aiResult = await _aiService.AnalyzeContractAsync(richTextBoxViewContract.Text, contractType);

                _lastAIResult = aiResult;
                DisplayAIResults(aiResult);
                tabResults.SelectedTab = tabPageAI;

                // 3. Özet Oluştur
                lblAIStatus.Text = "Ollama: Özet oluşturuluyor...";
                lblAIStatus.ForeColor = UIStyleHelper.AccentPurple;

                bool isDetailed = rbDetailedSummary.Checked;
                ContractSummaryResult summary;

                if (isDetailed)
                    summary = await _aiService.GetDetailedSummaryAsync(richTextBoxViewContract.Text);
                else
                    summary = await _aiService.GetBriefSummaryAsync(richTextBoxViewContract.Text);

                DisplayStructuredSummary(summary, isDetailed);
                tabResults.SelectedTab = tabPageSummary;

                // 4. AI ile Alan Çıkarma
                lblAIStatus.Text = "Ollama: Alanlar çıkarılıyor...";
                lblAIStatus.ForeColor = UIStyleHelper.AccentPurple;

                var extractions = await _aiService.ExtractFieldsAsync(
                    richTextBoxViewContract.Text,
                    comboboxContractType.Text);

                if (_currentContractId == 0)
                {
                    _currentContractId = _contractService.CreateContract(
                        Path.GetFileName(_selectedFilePath),
                        _selectedFilePath,
                        richTextBoxViewContract.Text,
                        comboboxContractType.Text,
                        (int)(_lastAnalysisResult?.TotalScore ?? 0));
                }

                _extractionService.SaveExtractionsWithChanges(_currentContractId, extractions);
                _dateService.SaveDatesFromExtractions(_currentContractId, extractions);
                DisplayExtractions(extractions);
                tabResults.SelectedTab = tabPageExtractions;

                // Tamamlandı
                lblAIStatus.Text = "Ollama: Bağlı";
                lblAIStatus.ForeColor = UIStyleHelper.AccentGreen;
            }
            catch (Exception ex)
            {
                lblAIStatus.Text = "Ollama: Hata";
                lblAIStatus.ForeColor = UIStyleHelper.AccentRed;
                rtbAIResults.Text = $"Analiz hatası:\n{ex.Message}";
            }
            finally
            {
                progressAI.Visible = false;
                btnAnalyze.Enabled = true;
                btnAnalyze.Text = "Sözleşmeyi Tam Analiz Et";
            }
        }

        private void DisplayStructuredSummary(ContractSummaryResult summary, bool isDetailed)
        {
            rtbSummary.Clear();

            string title = isDetailed ? "DETAYLI SÖZLEŞME ÖZETİ" : "SÖZLEŞME ÖZETİ";
            rtbSummary.SelectionFont = new Font("Segoe UI", 13f, FontStyle.Bold);
            rtbSummary.SelectionColor = UIStyleHelper.AccentBlue;
            rtbSummary.AppendText(title + "\n");
            rtbSummary.AppendText("═".PadRight(45, '═') + "\n\n");

            if (!string.IsNullOrEmpty(summary.Purpose))
            {
                AddSummarySection(rtbSummary, "AMAÇ / KAPSAM", summary.Purpose);
            }

            if (!string.IsNullOrEmpty(summary.Parties))
            {
                AddSummarySection(rtbSummary, "TARAFLAR & İLİŞKİ", summary.Parties);
            }

            if (!string.IsNullOrEmpty(summary.Duration))
            {
                AddSummarySection(rtbSummary, "SÜRE & TARİHLER", summary.Duration);
            }

            if (!string.IsNullOrEmpty(summary.Termination))
            {
                AddSummarySection(rtbSummary, "FESİH & YENİLEME", summary.Termination);
            }

            if (!string.IsNullOrEmpty(summary.Payment))
            {
                AddSummarySection(rtbSummary, "ÖDEME / TUTAR", summary.Payment);
            }

            if (summary.KeyObligations.Count > 0)
            {
                rtbSummary.SelectionFont = new Font("Segoe UI", 11f, FontStyle.Bold);
                rtbSummary.SelectionColor = UIStyleHelper.AccentOrange;
                rtbSummary.AppendText("KRİTİK YÜKÜMLÜLÜKLER\n");
                rtbSummary.AppendText("─".PadRight(40, '─') + "\n");

                foreach (var obligation in summary.KeyObligations)
                {
                    rtbSummary.SelectionFont = new Font("Segoe UI", 10f);
                    rtbSummary.SelectionColor = UIStyleHelper.PrimaryText;
                    rtbSummary.AppendText($"  • {obligation}\n");
                }
                rtbSummary.AppendText("\n");
            }

            if (summary.Risks.Count > 0)
            {
                rtbSummary.SelectionFont = new Font("Segoe UI", 11f, FontStyle.Bold);
                rtbSummary.SelectionColor = UIStyleHelper.AccentRed;
                rtbSummary.AppendText("RİSK / UYARILAR\n");
                rtbSummary.AppendText("─".PadRight(40, '─') + "\n");

                foreach (var risk in summary.Risks)
                {
                    rtbSummary.SelectionFont = new Font("Segoe UI", 10f);
                    rtbSummary.SelectionColor = UIStyleHelper.AccentOrange;
                    rtbSummary.AppendText($"  ⚠ {risk}\n");
                }
                rtbSummary.AppendText("\n");
            }

            rtbSummary.SelectionFont = new Font("Segoe UI", 8f, FontStyle.Italic);
            rtbSummary.SelectionColor = UIStyleHelper.MutedText;
            rtbSummary.AppendText("─".PadRight(40, '─') + "\n");
            rtbSummary.AppendText("Kaynak: Belge içeriğinden AI tarafından otomatik oluşturulmuştur.\n");
        }

        private void AddSummarySection(RichTextBox rtb, string sectionTitle, string content)
        {
            rtb.SelectionFont = new Font("Segoe UI", 11f, FontStyle.Bold);
            rtb.SelectionColor = UIStyleHelper.AccentGreen;
            rtb.AppendText($"{sectionTitle}\n");
            rtb.AppendText("─".PadRight(40, '─') + "\n");
            rtb.SelectionFont = new Font("Segoe UI", 10f);
            rtb.SelectionColor = UIStyleHelper.PrimaryText;
            rtb.AppendText($"  {content}\n\n");
        }

        private void DisplayAIResults(AIService.AIAnalysisResult result)
        {
            rtbAIResults.Clear();

            rtbAIResults.SelectionFont = new Font("Segoe UI", 14f, FontStyle.Bold);
            rtbAIResults.SelectionColor = UIStyleHelper.AccentBlue;
            rtbAIResults.AppendText("AI ANALİZ RAPORU\n");
            rtbAIResults.AppendText("═".PadRight(45, '═') + "\n\n");

            rtbAIResults.SelectionFont = new Font("Segoe UI", 11f, FontStyle.Bold);
            rtbAIResults.SelectionColor = UIStyleHelper.AccentGreen;
            rtbAIResults.AppendText($"Risk Skoru: {result.RiskScore}/100\n");
            rtbAIResults.SelectionColor = GetRiskColor(result.RiskScore);
            rtbAIResults.AppendText($"Risk Seviyesi: {result.RiskLevel}\n\n");

            if (!string.IsNullOrEmpty(result.Summary))
            {
                rtbAIResults.SelectionFont = new Font("Segoe UI", 11f, FontStyle.Bold);
                rtbAIResults.SelectionColor = UIStyleHelper.PrimaryText;
                rtbAIResults.AppendText("ÖZET\n");
                rtbAIResults.AppendText("─".PadRight(40, '─') + "\n");
                rtbAIResults.SelectionFont = new Font("Segoe UI", 10f);
                rtbAIResults.AppendText(result.Summary + "\n\n");
            }

            if (result.Details != null && result.Details.Count > 0)
            {
                rtbAIResults.SelectionFont = new Font("Segoe UI", 11f, FontStyle.Bold);
                rtbAIResults.SelectionColor = UIStyleHelper.PrimaryText;
                rtbAIResults.AppendText("MADDE DETAYLARI\n");
                rtbAIResults.AppendText("─".PadRight(40, '─') + "\n");

                foreach (var detail in result.Details)
                {
                    rtbAIResults.SelectionFont = new Font("Segoe UI", 10f, FontStyle.Bold);
                    rtbAIResults.SelectionColor = GetRiskDetailColor(detail.Risk);
                    rtbAIResults.AppendText($"  [{detail.Risk}] {detail.Title}\n");
                    rtbAIResults.SelectionFont = new Font("Segoe UI", 9.5f);
                    rtbAIResults.SelectionColor = UIStyleHelper.SecondaryText;
                    rtbAIResults.AppendText($"    {detail.Content}\n");
                    rtbAIResults.AppendText($"    Açıklama: {detail.Explanation}\n\n");
                }
            }

            if (result.Recommendations != null && result.Recommendations.Count > 0)
            {
                rtbAIResults.SelectionFont = new Font("Segoe UI", 11f, FontStyle.Bold);
                rtbAIResults.SelectionColor = UIStyleHelper.PrimaryText;
                rtbAIResults.AppendText("ÖNERİLER\n");
                rtbAIResults.AppendText("─".PadRight(40, '─') + "\n");
                foreach (var rec in result.Recommendations)
                {
                    rtbAIResults.SelectionFont = new Font("Segoe UI", 10f);
                    rtbAIResults.SelectionColor = UIStyleHelper.AccentGreen;
                    rtbAIResults.AppendText($"  ✓ {rec}\n\n");
                }
            }

            if (!string.IsNullOrEmpty(result.RawResponse) && (result.Details?.Count ?? 0) == 0)
            {
                rtbAIResults.SelectionFont = new Font("Segoe UI", 11f, FontStyle.Bold);
                rtbAIResults.SelectionColor = UIStyleHelper.AccentOrange;
                rtbAIResults.AppendText("\nHAM AI YANITI:\n");
                rtbAIResults.AppendText("─".PadRight(40, '─') + "\n");
                rtbAIResults.SelectionFont = new Font("Consolas", 9f);
                rtbAIResults.SelectionColor = UIStyleHelper.SecondaryText;
                rtbAIResults.AppendText(result.RawResponse);
            }
        }

        private Color GetRiskColor(double score)
        {
            if (score >= 75) return UIStyleHelper.AccentGreen;
            if (score >= 40) return UIStyleHelper.AccentOrange;
            return UIStyleHelper.AccentRed;
        }

        private Color GetRiskDetailColor(string risk)
        {
            if (string.IsNullOrEmpty(risk)) return UIStyleHelper.SecondaryText;
            return risk.ToLower() switch
            {
                "düşük" => UIStyleHelper.AccentGreen,
                "orta" => UIStyleHelper.AccentOrange,
                "yüksek" => UIStyleHelper.AccentRed,
                "kritik" => Color.FromArgb(180, 0, 0),
                _ => UIStyleHelper.SecondaryText
            };
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (_lastAnalysisResult == null || dataGridViewResultScreen.Rows.Count == 0)
            {
                MessageBox.Show("Rapor oluşturulabilmesi için önce 'Sözleşmeyi Analiz Et' butonuna basmalısınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog { Filter = "PDF Dosyası (*.pdf)|*.pdf", FileName = "AnalizRaporu.pdf" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _exportService.ExportDirectToPdf(sfd.FileName, _lastAnalysisResult, comboboxContractType.Text, _lastAIResult);
                        MessageBox.Show("Rapor başarıyla PDF olarak oluşturuldu!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo { FileName = sfd.FileName, UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("PDF oluşturulurken bir hata meydana geldi: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnManageRules_Click(object sender, EventArgs e)
        {
            using (RuleManagementForm manageForm = new RuleManagementForm())
            {
                manageForm.ShowDialog();
                LoadComboBox();
                _lastAnalysisResult = null;
            }
        }

        private void btnTemplates_Click(object sender, EventArgs e)
        {
            using (var templateForm = new TemplateListForm())
            {
                templateForm.ShowDialog(this);
            }
        }

        private void btnContractManagement_Click(object sender, EventArgs e)
        {
            using (var contractListForm = new ContractListForm())
            {
                if (contractListForm.ShowDialog() == DialogResult.OK)
                {
                    var selected = contractListForm.SelectedContract;
                    if (selected != null)
                    {
                        LoadContractToMainScreen(selected);
                    }
                }
            }
        }

        private void LoadContractToMainScreen(ContractListItem contract)
        {
            try
            {
                // Sözleşme türünü seç
                for (int i = 0; i < comboboxContractType.Items.Count; i++)
                {
                    var item = comboboxContractType.Items[i] as ContractTypes;
                    if (item?.TypeName == contract.TypeName)
                    {
                        comboboxContractType.SelectedIndex = i;
                        break;
                    }
                }

                // Dosya içeriğini yükle (eğer dosya hâlâ mevcutsa)
                if (!string.IsNullOrEmpty(contract.FilePath) && File.Exists(contract.FilePath))
                {
                    _selectedFilePath = contract.FilePath;
                    richTextBoxViewContract.Text = _fileService.ReadDocument(_selectedFilePath);

                    // Önceki sonuçları temizle
                    richTextBoxViewContract.ClearHighlights();
                    dataGridViewResultScreen.Rows.Clear();
                    dgvSearchResults.Rows.Clear();
                    _lastAnalysisResult = null;
                    _lastAIResult = null;
                    rtbAIResults.Clear();
                    rtbSummary.Clear();
                    rtbExtractions.Clear();
                    _currentContractId = contract.Id;

                    // Mevcut çıkarılan alanları yükle
                    var extractions = _extractionService.GetExtractions(contract.Id);
                    if (extractions.Any())
                    {
                        var extractionDict = extractions.ToDictionary(e => e.FieldName, e => e.FieldValue);
                        DisplayExtractions(extractionDict);
                        _dateService.SaveDatesFromExtractions(contract.Id, extractionDict);
                    }

                    lblAIStatus.Text = $"Yüklenen: {contract.FileName}";
                    lblAIStatus.ForeColor = UIStyleHelper.AccentGreen;
                }
                else
                {
                    MessageBox.Show("Sözleşme dosyası bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Sözleşme yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayExtractions(Dictionary<string, string> extractions)
        {
            rtbExtractions.Clear();

            rtbExtractions.SelectionFont = new Font("Segoe UI", 13f, FontStyle.Bold);
            rtbExtractions.SelectionColor = UIStyleHelper.AccentBlue;
            rtbExtractions.AppendText("ÇIKARILAN ALANLAR\n");
            rtbExtractions.AppendText("═".PadRight(45, '═') + "\n\n");

            foreach (var kvp in extractions)
            {
                string displayName = _extractionService.GetFieldDisplayName(kvp.Key);
                bool found = kvp.Value != "Bulunamadı" && !string.IsNullOrWhiteSpace(kvp.Value);

                rtbExtractions.SelectionFont = new Font("Segoe UI", 10f, FontStyle.Bold);
                rtbExtractions.SelectionColor = found ? UIStyleHelper.AccentGreen : UIStyleHelper.AccentOrange;
                rtbExtractions.AppendText($"{displayName}\n");

                rtbExtractions.SelectionFont = new Font("Segoe UI", 9.5f);
                rtbExtractions.SelectionColor = found ? UIStyleHelper.PrimaryText : UIStyleHelper.SecondaryText;
                rtbExtractions.AppendText($"  {kvp.Value}\n\n");
            }

            rtbExtractions.SelectionFont = new Font("Segoe UI", 8f, FontStyle.Italic);
            rtbExtractions.SelectionColor = UIStyleHelper.MutedText;
            rtbExtractions.AppendText("─".PadRight(40, '─') + "\n");
            rtbExtractions.AppendText("Düzenlemek için sözleşme detay formunu kullanın.\n");
        }

        private void richTextBoxViewContract_TextChanged(object sender, EventArgs e)
        {
            _lastAnalysisResult = null;
        }
    }
}
