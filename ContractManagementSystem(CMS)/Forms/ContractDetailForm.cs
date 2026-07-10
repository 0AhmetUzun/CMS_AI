using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContractManagementSystem_CMS_.Extensions;
using ContractManagementSystem_CMS_.Models;
using ContractManagementSystem_CMS_.Services;

namespace ContractManagementSystem_CMS_.Forms
{
    public partial class ContractDetailForm : Form
    {
        private readonly ContractListItem _contract;
        private readonly ExtractionService _extractionService;
        private readonly ContractService _contractService;
        private List<ContractExtraction> _extractions = new();
        private Dictionary<string, TextBox> _fieldTextBoxes = new();

        public ContractDetailForm(ContractListItem contract)
        {
            InitializeComponent();
            _contract = contract;
            _extractionService = new ExtractionService();
            _contractService = new ContractService();
            ApplyTheme();
            LoadContractDetails();
        }

        private void ApplyTheme()
        {
            this.BackColor = UIStyleHelper.PrimaryBg;
            this.ForeColor = UIStyleHelper.PrimaryText;

            lblTitle.ForeColor = UIStyleHelper.AccentBlue;
            lblFileName.ForeColor = UIStyleHelper.PrimaryText;
            lblTypeName.ForeColor = UIStyleHelper.SecondaryText;
            lblRiskScore.ForeColor = UIStyleHelper.AccentGreen;

            btnExtract.BackColor = UIStyleHelper.AccentPurple;
            btnExtract.ForeColor = Color.White;
            btnExtract.FlatStyle = FlatStyle.Flat;
            btnExtract.FlatAppearance.BorderSize = 0;

            btnSave.BackColor = UIStyleHelper.AccentGreen;
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;

            btnClose.BackColor = UIStyleHelper.AccentBg;
            btnClose.ForeColor = UIStyleHelper.PrimaryText;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderColor = UIStyleHelper.BorderColor;
            btnClose.FlatAppearance.BorderSize = 1;

            panelFields.AutoScroll = true;
        }

        private void LoadContractDetails()
        {
            lblFileName.Text = $"📄 {_contract.FileName}";
            lblTypeName.Text = $"Tür: {_contract.TypeName ?? "Belirsiz"}";
            
            string riskColor = _contract.RiskScore >= 75 ? "🟢" : _contract.RiskScore >= 40 ? "🟡" : "🔴";
            lblRiskScore.Text = $"Risk: {_contract.RiskScore} {riskColor}";

            LoadExtractions();
        }

        private void LoadExtractions()
        {
            _extractions = _extractionService.GetExtractions(_contract.Id);
            _fieldTextBoxes.Clear();
            panelFields.Controls.Clear();

            string[] fieldNames = {
                "BaslangicTarihi", "BitisTarihi", "Sure", "FesihTuru",
                "FesihBildirimSuresi", "Yenileme", "YenilemeBildirimSuresi",
                "OdemeTutari", "OdemeVadesi", "GecikmeCezasi", "CezaiSart",
                "Teminat", "SLA"
            };

            int yPos = 10;

            foreach (var fieldName in fieldNames)
            {
                var extraction = _extractions.FirstOrDefault(e => e.FieldName == fieldName);
                string displayName = _extractionService.GetFieldDisplayName(fieldName);
                string value = extraction?.FieldValue ?? "";

                var panel = CreateFieldPanel(fieldName, displayName, value, yPos);
                panelFields.Controls.Add(panel);
                yPos += 60;
            }
        }

        private Panel CreateFieldPanel(string fieldName, string displayName, string value, int y)
        {
            var panel = new Panel
            {
                Size = new Size(700, 50),
                Location = new Point(10, y),
                BackColor = UIStyleHelper.CardBg
            };

            var lblFieldName = new Label
            {
                Text = displayName,
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                ForeColor = UIStyleHelper.AccentBlue,
                Location = new Point(10, 5),
                AutoSize = true
            };
            panel.Controls.Add(lblFieldName);

            var txtValue = new TextBox
            {
                Text = value,
                Font = new Font("Segoe UI", 9f),
                BackColor = UIStyleHelper.AccentBg,
                ForeColor = UIStyleHelper.PrimaryText,
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(10, 28),
                Size = new Size(680, 22),
                Tag = fieldName
            };
            panel.Controls.Add(txtValue);
            _fieldTextBoxes[fieldName] = txtValue;

            return panel;
        }

        private async void btnExtract_Click(object sender, EventArgs e)
        {
            try
            {
                btnExtract.Enabled = false;
                btnExtract.Text = "AI ile çıkarılıyor...";
                Cursor = Cursors.WaitCursor;

                var extractions = await _extractionService.ExtractFromDocumentAsync(
                    _contract.FileName, _contract.TypeName ?? "");

                foreach (var kvp in extractions)
                {
                    if (_fieldTextBoxes.ContainsKey(kvp.Key))
                    {
                        _fieldTextBoxes[kvp.Key].Text = kvp.Value;
                    }
                }

                MessageBox.Show(
                    "AI ile alan çıkarma işlemi tamamlandı.\n\nSonuçları inleyip 'Kaydet' butonu ile kaydedebilirsiniz.",
                    "Başarılı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"AI çıkarma sırasında hata oluştu: {ex.Message}",
                    "Hata",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btnExtract.Enabled = true;
                btnExtract.Text = "🤖 AI ile Çıkar";
                Cursor = Cursors.Default;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var newValues = new Dictionary<string, string>();
                foreach (var kvp in _fieldTextBoxes)
                {
                    newValues[kvp.Key] = kvp.Value.Text.Trim();
                }

                var changes = _extractionService.SaveExtractionsWithChanges(_contract.Id, newValues);

                if (changes.Any(c => c.IsChanged))
                {
                    using var changesForm = new ChangesSummaryForm(changes, _contract.FileName, _contract.Id);
                    var result = changesForm.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        MessageBox.Show(
                            "Değişiklikler başarıyla kaydedildi.",
                            "Başarılı",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(
                        "Herhangi bir değişiklik yapılmadı.",
                        "Bilgi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }

                LoadExtractions();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Kaydetme sırasında hata oluştu: {ex.Message}",
                    "Hata",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
