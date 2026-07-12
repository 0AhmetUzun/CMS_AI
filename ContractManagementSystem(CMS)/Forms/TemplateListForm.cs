using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ContractManagementSystem_CMS_.Extensions;
using ContractManagementSystem_CMS_.Models;
using ContractManagementSystem_CMS_.Services;

namespace ContractManagementSystem_CMS_.Forms
{
    public partial class TemplateListForm : Form
    {
        private readonly TemplateService _templateService = new TemplateService();
        private DataGridView dgvTemplates = new DataGridView();
        private Button btnNew = new Button();
        private Button btnEdit = new Button();
        private Button btnDelete = new Button();
        private Button btnGenerate = new Button();
        private Button btnClose = new Button();

        public TemplateListForm()
        {
            InitializeComponent();
            ApplyTheme();
            LoadTemplates();
        }

        private void InitializeComponent()
        {
            this.Text = "Sözleşme Şablonları";
            this.Size = new Size(640, 460);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            dgvTemplates = new DataGridView
            {
                Location = new Point(12, 12),
                Size = new Size(604, 340),
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                MultiSelect = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                ReadOnly = true
            };
            dgvTemplates.Columns.Add("TemplateName", "Şablon Adı");
            dgvTemplates.Columns.Add("TemplateType", "Türü");
            var builtInCol = new DataGridViewColumn(new DataGridViewTextBoxCell()) { Name = "BuiltIn", HeaderText = "Hazır", Width = 60 };
            dgvTemplates.Columns.Add(builtInCol);
            var idCol = new DataGridViewColumn(new DataGridViewTextBoxCell()) { Name = "Id", Visible = false };
            dgvTemplates.Columns.Add(idCol);
            dgvTemplates.Columns["TemplateName"].Width = 320;
            dgvTemplates.Columns["TemplateType"].Width = 180;
            dgvTemplates.CellDoubleClick += DgvTemplates_CellDoubleClick;
            this.Controls.Add(dgvTemplates);

            btnNew = new Button { Text = "➕ Yeni Oluştur", Location = new Point(12, 362), Size = new Size(140, 34) };
            btnEdit = new Button { Text = "✏️ Düzenle", Location = new Point(162, 362), Size = new Size(120, 34) };
            btnDelete = new Button { Text = "🗑️ Sil", Location = new Point(292, 362), Size = new Size(110, 34) };
            btnGenerate = new Button { Text = "📄 Bu Şablondan Üret", Location = new Point(412, 362), Size = new Size(150, 34) };
            btnClose = new Button { Text = "Kapat", Location = new Point(536, 408), Size = new Size(80, 28) };

            btnNew.Click += BtnNew_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
            btnGenerate.Click += BtnGenerate_Click;
            btnClose.Click += (s, e) => this.Close();

            this.Controls.Add(btnNew);
            this.Controls.Add(btnEdit);
            this.Controls.Add(btnDelete);
            this.Controls.Add(btnGenerate);
            this.Controls.Add(btnClose);
        }

        private void ApplyTheme()
        {
            this.BackColor = UIStyleHelper.PrimaryBg;
            this.ForeColor = UIStyleHelper.PrimaryText;
            UIStyleHelper.ApplyModernTableTheme(dgvTemplates);
            UIStyleHelper.ApplyButtonTheme(btnNew, UIStyleHelper.AccentGreen, Color.White);
            UIStyleHelper.ApplyButtonTheme(btnEdit, UIStyleHelper.AccentBlue, Color.White);
            UIStyleHelper.ApplyButtonTheme(btnDelete, UIStyleHelper.AccentRed, Color.White);
            UIStyleHelper.ApplyButtonTheme(btnGenerate, UIStyleHelper.AccentTeal, Color.White);
            UIStyleHelper.ApplyButtonTheme(btnClose, UIStyleHelper.AccentBg, UIStyleHelper.PrimaryText);
        }

        private void LoadTemplates()
        {
            dgvTemplates.Rows.Clear();
            var templates = _templateService.GetAllTemplates();
            foreach (var t in templates)
            {
                dgvTemplates.Rows.Add(t.TemplateName, t.TemplateType ?? "-", t.IsBuiltIn ? "Evet" : "", t.Id);
            }
            if (dgvTemplates.Rows.Count > 0) dgvTemplates.Rows[0].Selected = true;
        }

        private ContractTemplate? GetSelected()
        {
            if (dgvTemplates.SelectedRows.Count == 0) return null;
            int id = (int)dgvTemplates.SelectedRows[0].Cells["Id"].Value;
            return _templateService.GetTemplateById(id);
        }

        private void BtnNew_Click(object? sender, EventArgs e)
        {
            using (var editor = new TemplateEditorForm(null))
            {
                if (editor.ShowDialog(this) == DialogResult.OK)
                    LoadTemplates();
            }
        }

        private void BtnEdit_Click(object? sender, EventArgs e)
        {
            var selected = GetSelected();
            if (selected == null) return;
            if (selected.IsBuiltIn)
            {
                MessageBox.Show("Hazır şablonlar düzenlenemez. Önce kopyalayıp yeni şablon olarak kaydedebilirsiniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (var editor = new TemplateEditorForm(selected))
            {
                if (editor.ShowDialog(this) == DialogResult.OK)
                    LoadTemplates();
            }
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            var selected = GetSelected();
            if (selected == null) return;
            if (selected.IsBuiltIn)
            {
                MessageBox.Show("Hazır şablonlar silinemez.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show($"'{selected.TemplateName}' şablonunu silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _templateService.DeleteTemplate(selected.Id);
                LoadTemplates();
            }
        }

        private void BtnGenerate_Click(object? sender, EventArgs e)
        {
            var selected = GetSelected();
            if (selected == null) return;
            using (var gen = new GenerateFromTemplateForm(selected))
            {
                gen.ShowDialog(this);
            }
        }

        private void DgvTemplates_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) BtnGenerate_Click(sender, e);
        }
    }
}
