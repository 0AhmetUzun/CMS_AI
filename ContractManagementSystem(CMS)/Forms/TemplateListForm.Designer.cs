namespace ContractManagementSystem_CMS_.Forms
{
    partial class TemplateListForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvTemplates;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnGenerate;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            dgvTemplates = new DataGridView();
            btnNew = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnGenerate = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTemplates).BeginInit();
            SuspendLayout();
            // 
            // dgvTemplates
            // 
            dgvTemplates.AllowUserToAddRows = false;
            dgvTemplates.AllowUserToDeleteRows = false;
            dgvTemplates.Columns.Add("TemplateName", "Şablon Adı");
            dgvTemplates.Columns["TemplateName"].Width = 320;
            dgvTemplates.Columns.Add("TemplateType", "Türü");
            dgvTemplates.Columns["TemplateType"].Width = 180;
            System.Windows.Forms.DataGridViewColumn builtInCol = new System.Windows.Forms.DataGridViewColumn();
            builtInCol.CellTemplate = new System.Windows.Forms.DataGridViewTextBoxCell();
            builtInCol.Name = "BuiltIn";
            builtInCol.HeaderText = "Hazır";
            builtInCol.Width = 60;
            dgvTemplates.Columns.Add(builtInCol);
            System.Windows.Forms.DataGridViewColumn idCol = new System.Windows.Forms.DataGridViewColumn();
            idCol.CellTemplate = new System.Windows.Forms.DataGridViewTextBoxCell();
            idCol.Name = "Id";
            idCol.Visible = false;
            dgvTemplates.Columns.Add(idCol);
            dgvTemplates.Location = new Point(12, 12);
            dgvTemplates.MultiSelect = false;
            dgvTemplates.Name = "dgvTemplates";
            dgvTemplates.ReadOnly = true;
            dgvTemplates.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTemplates.Size = new Size(604, 340);
            dgvTemplates.TabIndex = 0;
            dgvTemplates.CellDoubleClick += DgvTemplates_CellDoubleClick;
            // 
            // btnNew
            // 
            btnNew.Location = new Point(12, 358);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(140, 34);
            btnNew.TabIndex = 1;
            btnNew.Text = "➕ Yeni Oluştur";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += BtnNew_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(158, 358);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(130, 34);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "✏️ Düzenle";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += BtnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(294, 358);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(110, 34);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "🗑️ Sil";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += BtnDelete_Click;
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(410, 358);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(206, 34);
            btnGenerate.TabIndex = 4;
            btnGenerate.Text = "📄 Bu Şablondan Üret";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += BtnGenerate_Click;
            // 
            // TemplateListForm
            // 
            ClientSize = new Size(624, 421);
            Controls.Add(dgvTemplates);
            Controls.Add(btnNew);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);
            Controls.Add(btnGenerate);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TemplateListForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Sözleşme Şablonları";
            ((System.ComponentModel.ISupportInitialize)dgvTemplates).EndInit();
            ResumeLayout(false);
        }

        #endregion

    }
}
