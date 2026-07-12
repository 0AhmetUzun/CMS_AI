using ContractManagementSystem_CMS_.Extensions;

namespace ContractManagementSystem_CMS_.Forms
{
    partial class LockScreenForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtPin;
        private System.Windows.Forms.Button btnUnlock;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblError;

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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.txtPin = new System.Windows.Forms.TextBox();
            this.lblError = new System.Windows.Forms.Label();
            this.btnUnlock = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = false;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = UIStyleHelper.PrimaryText;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(380, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🔒 Sözleşme Yönetim Sistemi";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = false;
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblInfo.ForeColor = UIStyleHelper.SecondaryText;
            this.lblInfo.Location = new System.Drawing.Point(20, 56);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(380, 36);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "Uygulamayı açmak için PIN girin.";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPin
            // 
            this.txtPin.BackColor = UIStyleHelper.SecondaryBg;
            this.txtPin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPin.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPin.ForeColor = UIStyleHelper.PrimaryText;
            this.txtPin.Location = new System.Drawing.Point(60, 100);
            this.txtPin.Name = "txtPin";
            this.txtPin.PasswordChar = '●';
            this.txtPin.Size = new System.Drawing.Size(280, 26);
            this.txtPin.TabIndex = 2;
            this.txtPin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtPin_KeyDown);
            // 
            // lblError
            // 
            this.lblError.AutoSize = false;
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblError.ForeColor = UIStyleHelper.AccentRed;
            this.lblError.Location = new System.Drawing.Point(20, 132);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(380, 22);
            this.lblError.TabIndex = 3;
            this.lblError.Text = "";
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnUnlock
            // 
            this.btnUnlock.Location = new System.Drawing.Point(60, 162);
            this.btnUnlock.Name = "btnUnlock";
            this.btnUnlock.Size = new System.Drawing.Size(135, 36);
            this.btnUnlock.TabIndex = 4;
            this.btnUnlock.Text = "Kilidi Aç";
            this.btnUnlock.UseVisualStyleBackColor = true;
            this.btnUnlock.Click += new System.EventHandler(this.BtnUnlock_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(205, 162);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(135, 36);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Çıkış";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // LockScreenForm
            // 
            this.AcceptButton = this.btnUnlock;
            this.CancelButton = this.btnCancel;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = UIStyleHelper.PrimaryBg;
            this.ClientSize = new System.Drawing.Size(420, 260);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.txtPin);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnUnlock);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LockScreenForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CMS - Kilit Ekranı";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
