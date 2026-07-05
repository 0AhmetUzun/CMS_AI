using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ContractManagementSystem_CMS_.Extensions;
using ContractManagementSystem_CMS_.Models;
using ContractManagementSystem_CMS_.Services;

namespace ContractManagementSystem_CMS_.Forms
{
    public partial class RuleManagementForm : Form
    {
        private readonly RuleService _ruleService = new RuleService();
        private readonly DatabaseService _dbService = new DatabaseService();
        private int _selectedRuleId = 0;
        private bool _isLoaded = false;

        public RuleManagementForm()
        {
            InitializeComponent();
            ApplyTheme();
            this.Load += RuleManagementForm_Load;
            cmbContractTypes.SelectedIndexChanged += cmbContractTypes_SelectedIndexChanged;
        }

        private void ApplyTheme()
        {
            this.BackColor = UIStyleHelper.PrimaryBg;
            this.ForeColor = UIStyleHelper.PrimaryText;

            UIStyleHelper.ApplyButtonTheme(btnSave, UIStyleHelper.AccentBlue, Color.White);
            UIStyleHelper.ApplyButtonTheme(btnDelete, UIStyleHelper.AccentRed, Color.White);
            UIStyleHelper.ApplyButtonTheme(btnClear, UIStyleHelper.AccentBg, UIStyleHelper.PrimaryText);
            UIStyleHelper.ApplyButtonTheme(btnAddType, UIStyleHelper.AccentGreen, Color.White);
            UIStyleHelper.ApplyButtonTheme(btnDeleteType, UIStyleHelper.AccentRed, Color.White);

            ApplyTextBoxTheme(txtRuleDescription);
            ApplyTextBoxTheme(txtPattern);

            numSeverity.BackColor = UIStyleHelper.AccentBg;
            numSeverity.ForeColor = UIStyleHelper.PrimaryText;

            chkIsForbidden.ForeColor = UIStyleHelper.PrimaryText;
            chkIsForbidden.Font = new Font("Segoe UI", 9.5f);
        }

        private void ApplyTextBoxTheme(TextBox txt)
        {
            if (txt == null) return;
            txt.BackColor = UIStyleHelper.AccentBg;
            txt.ForeColor = UIStyleHelper.PrimaryText;
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.Font = new Font("Segoe UI", 9.5f);
        }

        private void RuleManagementForm_Load(object sender, EventArgs e)
        {
            LoadContractTypes();
            _isLoaded = true;
            RefreshGrid();
        }

        private void LoadContractTypes()
        {
            try
            {
                var types = _dbService.GetAllTypes();
                cmbContractTypes.DataSource = types;
                cmbContractTypes.DisplayMember = "TypeName";
                cmbContractTypes.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sözleşme türleri yüklenirken hata: " + ex.Message);
            }
        }

        private void RefreshGrid()
        {
            if (!_isLoaded) return;

            if (cmbContractTypes.SelectedValue != null && int.TryParse(cmbContractTypes.SelectedValue.ToString(), out int typeId))
            {
                try
                {
                    var allRules = _ruleService.GetAllRules();
                    var filteredRules = allRules.Where(r => r.TypeId == typeId).ToList();

                    dgvRules.AutoGenerateColumns = false;
                    dgvRules.DataSource = null;
                    dgvRules.DataSource = filteredRules;
                    dgvRules.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    UIStyleHelper.ApplyModernTableTheme(dgvRules);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kurallar listelenirken hata oluştu: " + ex.Message);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPattern.Text) || string.IsNullOrWhiteSpace(txtRuleDescription.Text))
            {
                MessageBox.Show("Lütfen 'Kural Metni' ve 'Aranacak Kelime' alanlarını doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbContractTypes.SelectedValue == null)
            {
                MessageBox.Show("Lütfen bir sözleşme türü seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var rule = new Rules
            {
                Id = _selectedRuleId,
                TypeId = (int)cmbContractTypes.SelectedValue,
                RuleDescription = txtRuleDescription.Text,
                Pattern = txtPattern.Text,
                IsForbidden = chkIsForbidden.Checked,
                Severity = (int)numSeverity.Value
            };

            try
            {
                if (_selectedRuleId == 0) _ruleService.AddRule(rule);
                else _ruleService.UpdateRule(rule);

                MessageBox.Show("İşlem başarıyla tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                RefreshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kural kaydedilirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvRules_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvRules.Rows[e.RowIndex];

                if (row.DataBoundItem != null)
                {
                    var rule = (Rules)row.DataBoundItem;

                    _selectedRuleId = rule.Id;
                    txtRuleDescription.Text = rule.RuleDescription ?? "";
                    txtPattern.Text = rule.Pattern ?? "";
                    chkIsForbidden.Checked = rule.IsForbidden;
                    numSeverity.Value = Convert.ToDecimal(rule.Severity);

                    btnSave.Text = "Kuralı Güncelle";
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedRuleId > 0)
            {
                var confirm = MessageBox.Show("Bu kuralı silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        _ruleService.DeleteRule(_selectedRuleId);
                        ClearForm();
                        RefreshGrid();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Kural silinirken hata: " + ex.Message);
                    }
                }
            }
        }

        private void ClearForm()
        {
            _selectedRuleId = 0;
            txtRuleDescription.Clear();
            txtPattern.Clear();
            chkIsForbidden.Checked = false;
            numSeverity.Value = 0;
            btnSave.Text = "Kural Ekle";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnAddType_Click(object sender, EventArgs e)
        {
            string newTypeName = Microsoft.VisualBasic.Interaction.InputBox("Eklenecek sözleşme türünün adını girin:", "Tür Ekle", "");

            if (!string.IsNullOrWhiteSpace(newTypeName))
            {
                try
                {
                    _dbService.AddContractType(newTypeName);
                    LoadContractTypes();
                    MessageBox.Show("Tür başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Tür eklenirken hata: " + ex.Message);
                }
            }
        }

        private void cmbContractTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void btnDeleteType_Click(object sender, EventArgs e)
        {
            if (cmbContractTypes.SelectedValue != null && int.TryParse(cmbContractTypes.SelectedValue.ToString(), out int typeId))
            {
                string typeName = cmbContractTypes.Text;

                var confirm = MessageBox.Show($"'{typeName}' türünü ve bu türe ait TÜM KURALLARI silmek istediğinize emin misiniz?",
                                              "Tür Silme Onayı",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        _dbService.DeleteContractType(typeId);
                        MessageBox.Show("Tür ve bağlı kurallar başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadContractTypes();
                        RefreshGrid();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Tür silinirken hata oluştu: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz türü seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
