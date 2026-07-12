using ContractManagementSystem_CMS_.Extensions;

namespace ContractManagementSystem_CMS_.Forms
{
    partial class TemplateEditorForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

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
            this.txtName = new System.Windows.Forms.TextBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.lblHint = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            System.Windows.Forms.Label lblName = new System.Windows.Forms.Label();
            System.Windows.Forms.Label lblType = new System.Windows.Forms.Label();
            System.Windows.Forms.Label lblContent = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblName
            // 
            lblName.Location = new System.Drawing.Point(12, 14);
            lblName.Name = "lblName";
            lblName.Size = new System.Drawing.Size(120, 20);
            lblName.Text = "Şablon Adı:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(12, 36);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(640, 24);
            this.txtName.TabIndex = 0;
            // 
            // lblType
            // 
            lblType.Location = new System.Drawing.Point(12, 70);
            lblType.Name = "lblType";
            lblType.Size = new System.Drawing.Size(120, 20);
            lblType.Text = "Türü:";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbType.Location = new System.Drawing.Point(12, 92);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(640, 24);
            this.cmbType.TabIndex = 1;
            // 
            // lblContent
            // 
            lblContent.Location = new System.Drawing.Point(12, 126);
            lblContent.Name = "lblContent";
            lblContent.Size = new System.Drawing.Size(640, 20);
            lblContent.Text = "Şablon Metni (alanlar [[AlanAdi]] şeklinde yazılır):";
            // 
            // txtContent
            // 
            this.txtContent.Font = new System.Drawing.Font("Consolas", 9.5F);
            this.txtContent.Location = new System.Drawing.Point(12, 148);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtContent.Size = new System.Drawing.Size(640, 320);
            this.txtContent.TabIndex = 2;
            // 
            // lblHint
            // 
            this.lblHint.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblHint.ForeColor = UIStyleHelper.SecondaryText;
            this.lblHint.Location = new System.Drawing.Point(12, 476);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(640, 32);
            this.lblHint.Text = "İpucu: [[Taraf1]] [[Taraf2]] [[Konu]] [[BaslangicTarihi]] [[BitisTarihi]] [[Sure]] [[Odeme]] [[FesihYenileme]] [[Ekler]] gibi alanlar, üretim sırasında otomatik form haline gelir.";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(482, 488);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Kaydet";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(580, 488);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 30);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "İptal";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // TemplateEditorForm
            // 
            this.Controls.Add(lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(lblType);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(lblContent);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.lblHint);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TemplateEditorForm";
            this.Size = new System.Drawing.Size(680, 560);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
