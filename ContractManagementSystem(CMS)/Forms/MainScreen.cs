using System;
using System.Collections.Generic;
using System.Drawing;
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

        private List<Rules> _activeRules = new List<Rules>();
        private string _selectedFilePath = "";

        private AnalysisResult _lastAnalysisResult = null;

        public MainScreen()
        {
            InitializeComponent();

            richTextBoxViewContract.AllowDrop = true;
            richTextBoxViewContract.EnableDragDrop();

            _dbService = new DatabaseService();
            _fileService = new FileService();
            _analysisEngine = new AnalysisEngine();
            _exportService = new ExportService();

            this.Load += MainScreen_Load;
            comboboxContractType.SelectedIndexChanged += comboboxContractType_SelectedIndexChanged;

        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            LoadComboBox();

            UIStyleHelper.ApplyModernTableTheme(dataGridViewResultScreen);
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

        private void comboboxContractType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboboxContractType.SelectedValue != null && int.TryParse(comboboxContractType.SelectedValue.ToString(), out int id))
            {
                _activeRules = _dbService.GetRulesByTypeId(id);
            }
        }

        private void btnFileSelection_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog { Filter = "Word Belgesi (*.docx)|*.docx" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _selectedFilePath = ofd.FileName;
                    try
                    {
                        richTextBoxViewContract.Text = _fileService.ReadWordDoc(_selectedFilePath);
                        richTextBoxViewContract.ClearHighlights();
                        dataGridViewResultScreen.Rows.Clear();
                        _lastAnalysisResult = null;

                        UIStyleHelper.ApplyModernTableTheme(dataGridViewResultScreen);
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
            }
        }

        private void btnFileChecking_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(richTextBoxViewContract.Text))
            {
                MessageBox.Show("L�tfen bir s�zle�me y�kleyin.", "Uyar�", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboboxContractType.SelectedValue == null || !int.TryParse(comboboxContractType.SelectedValue.ToString(), out int selectedId))
            {
                MessageBox.Show("L�tfen bir s�zle�me t�r� se�in.", "Uyar�", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                richTextBoxViewContract.ClearHighlights();
                dataGridViewResultScreen.Rows.Clear();

                var localResult = _analysisEngine.PerformAnalysis(richTextBoxViewContract.Text, selectedId);

                if (localResult == null)
                {
                    localResult = new AnalysisResult { TotalScore = 0, Details = new List<AnalysisDetail>() };
                }

                foreach (var detail in localResult.Details)
                {
                    dataGridViewResultScreen.Rows.Add(detail.RuleDescription, detail.Status);

                    if (detail.BoyaRengi != Color.Empty && !string.IsNullOrEmpty(detail.Pattern))
                    {
                        richTextBoxViewContract.HighlightPattern(detail.Pattern, detail.BoyaRengi);
                    }
                }

                UpdateStatusUI(localResult.TotalScore);

                _lastAnalysisResult = localResult;

                UIStyleHelper.ApplyModernTableTheme(dataGridViewResultScreen);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Analiz hatas�: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStatusUI(int score)
        {
            lblScoreText.Text = $"Risk Skoru: {score}";
            if (score >= 75) pnlRiskStatus.BackColor = Color.Yellow;
            else pnlRiskStatus.BackColor = Color.Red;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (_lastAnalysisResult == null || dataGridViewResultScreen.Rows.Count == 0)
            {
                MessageBox.Show("Rapor olu�turulabilmesi i�in �nce 'S�zle�meyi Analiz Et' butonuna basmal�s�n�z.", "Uyar�", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog { Filter = "PDF Dosyas� (*.pdf)|*.pdf", FileName = "AnalizRaporu.pdf" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _exportService.ExportDirectToPdf(sfd.FileName, _lastAnalysisResult, comboboxContractType.Text);

                        MessageBox.Show("Rapor ba�ar�yla PDF olarak olu�turuldu!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = sfd.FileName,
                            UseShellExecute = true
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("PDF olu�turulurken bir hata meydana geldi: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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