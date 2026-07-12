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

        public TemplateListForm()
        {
            InitializeComponent();
            ApplyTheme();
            LoadTemplates();
        }

        private void BtnClose_Click(object? sender, EventArgs e)
        {
            this.Close();
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
