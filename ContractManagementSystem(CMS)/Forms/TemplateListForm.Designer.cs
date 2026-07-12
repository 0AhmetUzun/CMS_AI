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
        private System.Windows.Forms.Button btnClose;

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
            this.dgvTemplates = new System.Windows.Forms.DataGridView();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTemplates)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTemplates
            // 
            this.dgvTemplates.AllowUserToAddRows = false;
            this.dgvTemplates.AllowUserToDeleteRows = false;
            this.dgvTemplates.Location = new System.Drawing.Point(12, 12);
            this.dgvTemplates.MultiSelect = false;
            this.dgvTemplates.Name = "dgvTemplates";
            this.dgvTemplates.ReadOnly = true;
            this.dgvTemplates.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTemplates.Size = new System.Drawing.Size(604, 340);
            this.dgvTemplates.TabIndex = 0;
            this.dgvTemplates.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvTemplates_CellDoubleClick);
            this.dgvTemplates.Columns.Add("TemplateName", "Şablon Adı");
            this.dgvTemplates.Columns["TemplateName"].Width = 320;
            this.dgvTemplates.Columns.Add("TemplateType", "Türü");
            this.dgvTemplates.Columns["TemplateType"].Width = 180;
            System.Windows.Forms.DataGridViewColumn builtInCol = new System.Windows.Forms.DataGridViewColumn();
            builtInCol.CellTemplate = new System.Windows.Forms.DataGridViewTextBoxCell();
            builtInCol.Name = "BuiltIn";
            builtInCol.HeaderText = "Hazır";
            builtInCol.Width = 60;
            this.dgvTemplates.Columns.Add(builtInCol);
            System.Windows.Forms.DataGridViewColumn idCol = new System.Windows.Forms.DataGridViewColumn();
            idCol.CellTemplate = new System.Windows.Forms.DataGridViewTextBoxCell();
            idCol.Name = "Id";
            idCol.Visible = false;
            this.dgvTemplates.Columns.Add(idCol);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(12, 362);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(140, 34);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "➕ Yeni Oluştur";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(162, 362);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(120, 34);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "✏️ Düzenle";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(292, 362);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(110, 34);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "🗑️ Sil";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(412, 362);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(150, 34);
            this.btnGenerate.TabIndex = 4;
            this.btnGenerate.Text = "📄 Bu Şablondan Üret";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(536, 408);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 28);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Kapat";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // TemplateListForm
            // 
            this.Controls.Add(this.dgvTemplates);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TemplateListForm";
            this.Size = new System.Drawing.Size(640, 460);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sözleşme Şablonları";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTemplates)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}
