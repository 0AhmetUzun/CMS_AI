using System;
using System.Drawing;
using System.Windows.Forms;
using ContractManagementSystem_CMS_.Extensions;
using ContractManagementSystem_CMS_.Models;
using ContractManagementSystem_CMS_.Services;

namespace ContractManagementSystem_CMS_.Forms
{
    public partial class TemplateEditorForm : Form
    {
        private readonly TemplateService _templateService = new TemplateService();
        private readonly DatabaseService _dbService = new DatabaseService();
        private readonly ContractTemplate? _editing;

        public TemplateEditorForm()
        {
            InitializeComponent();
        }

        public TemplateEditorForm(ContractTemplate? template) : this()
        {
            _editing = template;
            ApplyTheme();
            LoadContractTypes();

            if (_editing != null)
            {
                txtName.Text = _editing.TemplateName;
                SelectType(_editing.TemplateType);
                txtContent.Text = _editing.Content;
                this.Text = "Şablonu Düzenle";
            }
            else
            {
                this.Text = "Yeni Şablon";
            }
        }

        private void BtnCancel_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void ApplyTheme()
        {
            this.BackColor = UIStyleHelper.PrimaryBg;
            this.ForeColor = UIStyleHelper.PrimaryText;
            foreach (Control c in this.Controls)
            {
                if (c is Label lbl && lbl != lblHint)
                {
                    lbl.ForeColor = UIStyleHelper.PrimaryText;
                    lbl.Font = new Font("Segoe UI", 9.5f);
                }
            }
            txtName.BackColor = UIStyleHelper.AccentBg;
            txtName.ForeColor = UIStyleHelper.PrimaryText;
            cmbType.BackColor = UIStyleHelper.AccentBg;
            cmbType.ForeColor = UIStyleHelper.PrimaryText;
            txtContent.BackColor = UIStyleHelper.AccentBg;
            txtContent.ForeColor = UIStyleHelper.PrimaryText;
            UIStyleHelper.ApplyButtonTheme(btnSave, UIStyleHelper.AccentGreen, Color.White);
            UIStyleHelper.ApplyButtonTheme(btnCancel, UIStyleHelper.AccentBg, UIStyleHelper.PrimaryText);
        }

        private void LoadContractTypes()
        {
            try
            {
                var types = _dbService.GetAllTypes();
                cmbType.DataSource = types;
                cmbType.DisplayMember = "TypeName";
                cmbType.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sözleşme türleri yüklenirken hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SelectType(string? typeName)
        {
            if (string.IsNullOrWhiteSpace(typeName) || cmbType.Items.Count == 0) return;
            for (int i = 0; i < cmbType.Items.Count; i++)
            {
                if (cmbType.Items[i] is ContractTypes t && t.TypeName == typeName)
                {
                    cmbType.SelectedIndex = i;
                    return;
                }
            }
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Lütfen şablon adını girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtContent.Text))
            {
                MessageBox.Show("Lütfen şablon metnini girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var template = new ContractTemplate
            {
                Id = _editing?.Id ?? 0,
                TemplateName = txtName.Text.Trim(),
                TemplateType = cmbType.SelectedItem is ContractTypes selected ? selected.TypeName : null,
                Content = txtContent.Text
            };

            try
            {
                _templateService.SaveTemplate(template);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Şablon kaydedilirken hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
