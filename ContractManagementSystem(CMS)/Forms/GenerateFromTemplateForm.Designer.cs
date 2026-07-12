using ContractManagementSystem_CMS_.Extensions;

namespace ContractManagementSystem_CMS_.Forms
{
    partial class GenerateFromTemplateForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlFields;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblStatus;

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
            this.pnlFields = new System.Windows.Forms.Panel();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnlFields
            // 
            this.pnlFields.AutoScroll = true;
            this.pnlFields.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFields.Location = new System.Drawing.Point(12, 12);
            this.pnlFields.Name = "pnlFields";
            this.pnlFields.Size = new System.Drawing.Size(680, 480);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(470, 504);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(140, 34);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "📄 Oluştur (.docx)";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(620, 504);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 34);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Kapat";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.ForeColor = UIStyleHelper.SecondaryText;
            this.lblStatus.Location = new System.Drawing.Point(12, 510);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(440, 24);
            // 
            // GenerateFromTemplateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlFields);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GenerateFromTemplateForm";
            this.Size = new System.Drawing.Size(720, 600);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Şablondan Sözleşme Üret";
            this.ResumeLayout(false);
        }

        #endregion
    }
}
