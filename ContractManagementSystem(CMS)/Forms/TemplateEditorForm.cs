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
        private TextBox txtName = new TextBox();
        private ComboBox cmbType = new ComboBox();
        private TextBox txtContent = new TextBox();
        private Label lblHint = new Label();
        private Button btnSave = new Button();
        private Button btnCancel = new Button();

        public TemplateEditorForm(ContractTemplate? template)
        {
            _editing = template;
            InitializeComponent();
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

        private void InitializeComponent()
        {
            this.Size = new Size(680, 560);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            var lblName = new Label { Text = "Şablon Adı:", Location = new Point(12, 14), Size = new Size(120, 20) };
            txtName = new TextBox { Location = new Point(12, 36), Size = new Size(640, 24) };
            var lblType = new Label { Text = "Türü:", Location = new Point(12, 70), Size = new Size(120, 20) };
            cmbType = new ComboBox
            {
                Location = new Point(12, 92),
                Size = new Size(640, 24),
                DropDownStyle = ComboBoxStyle.DropDownList,
                FlatStyle = FlatStyle.Flat
            };
            var lblContent = new Label { Text = "Şablon Metni (alanlar [[AlanAdi]] şeklinde yazılır):", Location = new Point(12, 126), Size = new Size(640, 20) };
            txtContent = new TextBox
            {
                Location = new Point(12, 148),
                Size = new Size(640, 320),
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                Font = new Font("Consolas", 9.5f)
            };
            lblHint = new Label
            {
                Text = "İpucu: [[Taraf1]] [[Taraf2]] [[Konu]] [[BaslangicTarihi]] [[BitisTarihi]] [[Sure]] [[Odeme]] [[FesihYenileme]] [[Ekler]] gibi alanlar, üretim sırasında otomatik form haline gelir.",
                Location = new Point(12, 476),
                Size = new Size(640, 32),
                ForeColor = UIStyleHelper.SecondaryText,
                Font = new Font("Segoe UI", 8.5f)
            };
            btnSave = new Button { Text = "Kaydet", Location = new Point(482, 488), Size = new Size(90, 30) };
            btnCancel = new Button { Text = "İptal", Location = new Point(580, 488), Size = new Size(80, 30) };

            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (s, e) => this.Close();

            this.Controls.Add(lblName);
            this.Controls.Add(txtName);
            this.Controls.Add(lblType);
            this.Controls.Add(cmbType);
            this.Controls.Add(lblContent);
            this.Controls.Add(txtContent);
            this.Controls.Add(lblHint);
            this.Controls.Add(btnSave);
            this.Controls.Add(btnCancel);
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
