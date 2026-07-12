using ContractManagementSystem_CMS_.Extensions;

namespace ContractManagementSystem_CMS_.Forms
{
    partial class UpcomingDatesForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label header;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button btnOk;

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
            header = new Label();
            panel = new Panel();
            btnOk = new Button();
            SuspendLayout();
            // 
            // header
            // 
            header.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            header.ForeColor = Color.FromArgb(255, 152, 0);
            header.Location = new Point(16, 14);
            header.Name = "header";
            header.Size = new Size(520, 24);
            header.TabIndex = 0;
            // 
            // panel
            // 
            panel.AutoScroll = true;
            panel.BackColor = Color.FromArgb(40, 40, 40);
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Location = new Point(16, 48);
            panel.Name = "panel";
            panel.Size = new Size(520, 300);
            panel.TabIndex = 1;
            // 
            // btnOk
            // 
            btnOk.DialogResult = DialogResult.OK;
            btnOk.Location = new Point(456, 360);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(80, 23);
            btnOk.TabIndex = 2;
            btnOk.Text = "Tamam";
            btnOk.UseVisualStyleBackColor = true;
            // 
            // UpcomingDatesForm
            // 
            AcceptButton = btnOk;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(544, 381);
            Controls.Add(header);
            Controls.Add(panel);
            Controls.Add(btnOk);
            Font = new Font("Segoe UI", 10F);
            ForeColor = Color.FromArgb(240, 240, 240);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UpcomingDatesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Yaklaşan Kritik Tarihler";
            ResumeLayout(false);
        }

        #endregion
    }
}
