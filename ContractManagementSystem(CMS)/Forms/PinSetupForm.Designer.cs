using ContractManagementSystem_CMS_.Extensions;

namespace ContractManagementSystem_CMS_.Forms
{
    partial class PinSetupForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.TextBox txtCurrent;
        private System.Windows.Forms.Label lblNew;
        private System.Windows.Forms.TextBox txtNew;
        private System.Windows.Forms.Label lblConfirm;
        private System.Windows.Forms.TextBox txtConfirm;
        private System.Windows.Forms.Label lblIdle;
        private System.Windows.Forms.ComboBox cmbIdle;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnDisable;
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.txtCurrent = new System.Windows.Forms.TextBox();
            this.lblNew = new System.Windows.Forms.Label();
            this.txtNew = new System.Windows.Forms.TextBox();
            this.lblConfirm = new System.Windows.Forms.Label();
            this.txtConfirm = new System.Windows.Forms.TextBox();
            this.lblIdle = new System.Windows.Forms.Label();
            this.cmbIdle = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnDisable = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = false;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = UIStyleHelper.PrimaryText;
            this.lblTitle.Location = new System.Drawing.Point(20, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(400, 30);
            this.lblTitle.Text = "Güvenlik Ayarları";
            // 
            // lblCurrent
            // 
            this.lblCurrent.ForeColor = UIStyleHelper.SecondaryText;
            this.lblCurrent.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblCurrent.Location = new System.Drawing.Point(20, 60);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(120, 22);
            this.lblCurrent.Text = "Mevcut PIN:";
            // 
            // txtCurrent
            // 
            this.txtCurrent.BackColor = UIStyleHelper.SecondaryBg;
            this.txtCurrent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCurrent.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtCurrent.ForeColor = UIStyleHelper.PrimaryText;
            this.txtCurrent.Location = new System.Drawing.Point(150, 58);
            this.txtCurrent.Name = "txtCurrent";
            this.txtCurrent.PasswordChar = '●';
            this.txtCurrent.Size = new System.Drawing.Size(240, 24);
            // 
            // lblNew
            // 
            this.lblNew.ForeColor = UIStyleHelper.SecondaryText;
            this.lblNew.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNew.Location = new System.Drawing.Point(20, 94);
            this.lblNew.Name = "lblNew";
            this.lblNew.Size = new System.Drawing.Size(120, 22);
            this.lblNew.Text = "Yeni PIN:";
            // 
            // txtNew
            // 
            this.txtNew.BackColor = UIStyleHelper.SecondaryBg;
            this.txtNew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNew.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtNew.ForeColor = UIStyleHelper.PrimaryText;
            this.txtNew.Location = new System.Drawing.Point(150, 92);
            this.txtNew.Name = "txtNew";
            this.txtNew.PasswordChar = '●';
            this.txtNew.Size = new System.Drawing.Size(240, 24);
            // 
            // lblConfirm
            // 
            this.lblConfirm.ForeColor = UIStyleHelper.SecondaryText;
            this.lblConfirm.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblConfirm.Location = new System.Drawing.Point(20, 128);
            this.lblConfirm.Name = "lblConfirm";
            this.lblConfirm.Size = new System.Drawing.Size(120, 22);
            this.lblConfirm.Text = "Yeni PIN (tekrar):";
            // 
            // txtConfirm
            // 
            this.txtConfirm.BackColor = UIStyleHelper.SecondaryBg;
            this.txtConfirm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfirm.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtConfirm.ForeColor = UIStyleHelper.PrimaryText;
            this.txtConfirm.Location = new System.Drawing.Point(150, 126);
            this.txtConfirm.Name = "txtConfirm";
            this.txtConfirm.PasswordChar = '●';
            this.txtConfirm.Size = new System.Drawing.Size(240, 24);
            // 
            // lblIdle
            // 
            this.lblIdle.ForeColor = UIStyleHelper.SecondaryText;
            this.lblIdle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblIdle.Location = new System.Drawing.Point(20, 166);
            this.lblIdle.Name = "lblIdle";
            this.lblIdle.Size = new System.Drawing.Size(140, 22);
            this.lblIdle.Text = "Kilitlenme süresi:";
            // 
            // cmbIdle
            // 
            this.cmbIdle.BackColor = UIStyleHelper.SecondaryBg;
            this.cmbIdle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIdle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbIdle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbIdle.ForeColor = UIStyleHelper.PrimaryText;
            this.cmbIdle.Location = new System.Drawing.Point(170, 164);
            this.cmbIdle.Name = "cmbIdle";
            this.cmbIdle.Size = new System.Drawing.Size(120, 24);
            this.cmbIdle.Items.AddRange(new object[] {
            "5 dakika",
            "10 dakika",
            "30 dakika",
            "60 dakika"});
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = false;
            this.lblStatus.ForeColor = UIStyleHelper.AccentGreen;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblStatus.Location = new System.Drawing.Point(20, 200);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(400, 22);
            this.lblStatus.Text = "";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(20, 234);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(190, 36);
            this.btnApply.TabIndex = 0;
            this.btnApply.Text = "PIN'i Etkinleştir / Değiştir";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.BtnApply_Click);
            // 
            // btnDisable
            // 
            this.btnDisable.Location = new System.Drawing.Point(225, 234);
            this.btnDisable.Name = "btnDisable";
            this.btnDisable.Size = new System.Drawing.Size(190, 36);
            this.btnDisable.TabIndex = 1;
            this.btnDisable.Text = "PIN'i Kapat";
            this.btnDisable.UseVisualStyleBackColor = true;
            this.btnDisable.Click += new System.EventHandler(this.BtnDisable_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(150, 284);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(140, 32);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Kapat";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // PinSetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = UIStyleHelper.PrimaryBg;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblCurrent);
            this.Controls.Add(this.txtCurrent);
            this.Controls.Add(this.lblNew);
            this.Controls.Add(this.txtNew);
            this.Controls.Add(this.lblConfirm);
            this.Controls.Add(this.txtConfirm);
            this.Controls.Add(this.lblIdle);
            this.Controls.Add(this.cmbIdle);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnDisable);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PinSetupForm";
            this.Size = new System.Drawing.Size(440, 360);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "🔒 Güvenlik Ayarları";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
