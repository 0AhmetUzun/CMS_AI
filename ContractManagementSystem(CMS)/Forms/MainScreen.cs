using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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

        private List<Rules> _activeRules = new List<Rules>();
        private string _selectedFilePath = "";
        private AnalysisResult? _lastAnalysisResult = null;
        private AIService.AIAnalysisResult? _lastAIResult = null;

        public MainScreen()
        {
            InitializeComponent();
            _dbService = new DatabaseService();
            _fileService = new FileService();
            _analysisEngine = new AnalysisEngine();
            _exportService = new ExportService();
            _aiService = new AIService();

            ApplyThemeToControls();
            InitializeEventHandlers();
            SetupTabControlTheme();
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
            UIStyleHelper.ApplyButtonTheme(btnSummarize, UIStyleHelper.AccentBg, UIStyleHelper.PrimaryText);
            UIStyleHelper.ApplyButtonTheme(btnManageRules, UIStyleHelper.AccentBg, UIStyleHelper.PrimaryText);
            UIStyleHelper.SetScoreIndicatorColor(pnlRiskStatus, 0);
        }

        private void InitializeEventHandlers()
        {
            richTextBoxViewContract.EnableDragDrop(filePath =>
            {
                _selectedFilePath = filePath;
                richTextBoxViewContract.ClearHighlights();
                dataGridViewResultScreen.Rows.Clear();
                _lastAnalysisResult = null;
                _lastAIResult = null;
                rtbAIResults.Clear();
                UIStyleHelper.ApplyModernTableTheme(dataGridViewResultScreen);
            });

            this.Load += MainScreen_Load;
            btnAIAnalyze.Click += btnAIAnalyze_Click;
            btnSummarize.Click += btnSummarize_Click;
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

        private void btnFileSelection_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog { Filter = "Tüm Sözleşme Dosyaları|*.docx;*.pdf|Word Belgesi (*.docx)|*.docx|PDF Dosyası (*.pdf)|*.pdf" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _selectedFilePath = ofd.FileName;
                    try
                    {
                        richTextBoxViewContract.Text = _fileService.ReadDocument(_selectedFilePath);
                        richTextBoxViewContract.ClearHighlights();
                        dataGridViewResultScreen.Rows.Clear();
                        _lastAnalysisResult = null;
                        _lastAIResult = null;
                        rtbAIResults.Clear();
                        UIStyleHelper.ApplyModernTableTheme(dataGridViewResultScreen);
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
            }
        }

        private async void btnFileChecking_Click(object sender, EventArgs e)
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
                richTextBoxViewContract.ClearHighlights();
                dataGridViewResultScreen.Rows.Clear();

                var localResult = _analysisEngine.PerformAnalysis(richTextBoxViewContract.Text, selectedId);
                if (localResult == null)
                    localResult = new AnalysisResult { TotalScore = 0, Details = new List<AnalysisDetail>() };

                foreach (var detail in localResult.Details)
                {
                    dataGridViewResultScreen.Rows.Add(detail.RuleDescription, detail.Status);
                    if (detail.BoyaRengi != Color.Empty && !string.IsNullOrEmpty(detail.Pattern))
                        richTextBoxViewContract.HighlightPattern(detail.Pattern, detail.BoyaRengi);
                }

                UpdateStatusUI(localResult.TotalScore);
                _lastAnalysisResult = localResult;
                UIStyleHelper.ApplyModernTableTheme(dataGridViewResultScreen);

                _ = PerformAIAnalysisAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Analiz hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task PerformAIAnalysisAsync()
        {
            try
            {
                this.Invoke(() =>
                {
                    progressAI.Visible = true;
                    progressAI.Style = ProgressBarStyle.Marquee;
                    lblAIStatus.Text = "Ollama: AI analiz ediliyor...";
                    lblAIStatus.ForeColor = UIStyleHelper.AccentPurple;
                    btnAIAnalyze.Enabled = false;
                });

                string contractType = comboboxContractType.Text;
                var aiResult = await _aiService.AnalyzeContractAsync(richTextBoxViewContract.Text, contractType);

                this.Invoke(() =>
                {
                    _lastAIResult = aiResult;
                    DisplayAIResults(aiResult);
                    progressAI.Visible = false;
                    btnAIAnalyze.Enabled = true;
                    lblAIStatus.Text = "Ollama: Bağlı";
                    lblAIStatus.ForeColor = UIStyleHelper.AccentGreen;
                    tabResults.SelectedTab = tabPageAI;
                });
            }
            catch (Exception ex)
            {
                this.Invoke(() =>
                {
                    progressAI.Visible = false;
                    btnAIAnalyze.Enabled = true;
                    lblAIStatus.Text = "Ollama: Hata";
                    lblAIStatus.ForeColor = UIStyleHelper.AccentRed;
                    rtbAIResults.Text = $"AI analiz hatası:\n{ex.Message}";
                });
            }
        }

        private async void btnAIAnalyze_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(richTextBoxViewContract.Text))
            {
                MessageBox.Show("Lütfen bir sözleşme yükleyin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            await PerformAIAnalysisAsync();
        }

        private async void btnSummarize_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(richTextBoxViewContract.Text))
            {
                MessageBox.Show("Lütfen bir sözleşme yükleyin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                progressAI.Visible = true;
                progressAI.Style = ProgressBarStyle.Marquee;
                lblAIStatus.Text = "Ollama: Özet oluşturuluyor...";
                lblAIStatus.ForeColor = UIStyleHelper.AccentPurple;
                btnSummarize.Enabled = false;

                string summary = await _aiService.SummarizeContractAsync(richTextBoxViewContract.Text);

                rtbAIResults.Clear();
                rtbAIResults.SelectionFont = new Font("Segoe UI", 13f, FontStyle.Bold);
                rtbAIResults.SelectionColor = UIStyleHelper.AccentBlue;
                rtbAIResults.AppendText("SÖZLEŞME ÖZETİ\n");
                rtbAIResults.AppendText("─".PadRight(40, '─') + "\n\n");
                rtbAIResults.SelectionFont = new Font("Segoe UI", 10.5f);
                rtbAIResults.SelectionColor = UIStyleHelper.PrimaryText;
                rtbAIResults.AppendText(summary);

                tabResults.SelectedTab = tabPageAI;
            }
            catch (Exception ex)
            {
                rtbAIResults.Text = $"Özet hatası:\n{ex.Message}";
            }
            finally
            {
                progressAI.Visible = false;
                btnSummarize.Enabled = true;
                lblAIStatus.Text = "Ollama: Bağlı";
                lblAIStatus.ForeColor = UIStyleHelper.AccentGreen;
            }
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

        private void UpdateStatusUI(int score)
        {
            lblScoreText.Text = $"Risk Skoru: {score}";
            UIStyleHelper.SetScoreIndicatorColor(pnlRiskStatus, score);
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

        private void richTextBoxViewContract_TextChanged(object sender, EventArgs e)
        {
            _lastAnalysisResult = null;
        }
    }
}
