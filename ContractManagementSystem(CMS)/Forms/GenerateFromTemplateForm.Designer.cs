using ContractManagementSystem_CMS_.Extensions;

namespace ContractManagementSystem_CMS_.Forms
{
    partial class GenerateFromTemplateForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlFields;
        private System.Windows.Forms.Button btnGenerate;
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
            pnlFields = new Panel();
            btnGenerate = new Button();
            lblStatus = new Label();
            SuspendLayout();
            // 
            // pnlFields
            // 
            pnlFields.AutoScroll = true;
            pnlFields.BorderStyle = BorderStyle.FixedSingle;
            pnlFields.Location = new Point(14, 16);
            pnlFields.Margin = new Padding(3, 4, 3, 4);
            pnlFields.Name = "pnlFields";
            pnlFields.Size = new Size(570, 639);
            pnlFields.TabIndex = 0;
            // 
            // btnGenerate
            // 
            btnGenerate.BackColor = Color.FromArgb(40, 167, 69);
            btnGenerate.Location = new Point(426, 672);
            btnGenerate.Margin = new Padding(3, 4, 3, 4);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(160, 45);
            btnGenerate.TabIndex = 0;
            btnGenerate.Text = "📄 Oluştur (.docx)";
            btnGenerate.UseVisualStyleBackColor = false;
            btnGenerate.Click += BtnGenerate_Click;
            // 
            // lblStatus
            // 
            lblStatus.ForeColor = Color.FromArgb(180, 180, 180);
            lblStatus.Location = new Point(14, 680);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(503, 32);
            lblStatus.TabIndex = 2;
            // 
            // GenerateFromTemplateForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 748);
            Controls.Add(pnlFields);
            Controls.Add(btnGenerate);
            Controls.Add(lblStatus);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "GenerateFromTemplateForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Şablondan Sözleşme Üret";
            ResumeLayout(false);
        }

        #endregion
    }
}
