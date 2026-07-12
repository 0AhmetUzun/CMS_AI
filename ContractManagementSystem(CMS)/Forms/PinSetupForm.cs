using System;
using System.Drawing;
using System.Windows.Forms;
using ContractManagementSystem_CMS_.Extensions;
using ContractManagementSystem_CMS_.Services;

namespace ContractManagementSystem_CMS_.Forms
{
    public partial class PinSetupForm : Form
    {
        private Label lblTitle = new Label();
        private Label lblCurrent = new Label();
        private TextBox txtCurrent = new TextBox();
        private Label lblNew = new Label();
        private TextBox txtNew = new TextBox();
        private Label lblConfirm = new Label();
        private TextBox txtConfirm = new TextBox();
        private Label lblIdle = new Label();
        private ComboBox cmbIdle = new ComboBox();
        private Label lblStatus = new Label();
        private Button btnApply = new Button();
        private Button btnDisable = new Button();
        private Button btnClose = new Button();

        public PinSetupForm()
        {
            InitializeComponent();
            LoadCurrentValues();
        }

        private void InitializeComponent()
        {
            this.Text = "🔒 Güvenlik Ayarları";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Size = new Size(440, 360);
            this.BackColor = UIStyleHelper.PrimaryBg;

            lblTitle.Text = "Güvenlik Ayarları";
            lblTitle.Font = new Font("Segoe UI", 14f, FontStyle.Bold);
            lblTitle.ForeColor = UIStyleHelper.PrimaryText;
            lblTitle.AutoSize = false;
            lblTitle.Location = new Point(20, 16);
            lblTitle.Size = new Size(400, 30);

            lblCurrent.Text = "Mevcut PIN:";
            lblCurrent.ForeColor = UIStyleHelper.SecondaryText;
            lblCurrent.Font = new Font("Segoe UI", 9.5f);
            lblCurrent.Location = new Point(20, 60);
            lblCurrent.Size = new Size(120, 22);

            txtCurrent.Location = new Point(150, 58);
            txtCurrent.Size = new Size(240, 24);
            txtCurrent.Font = new Font("Segoe UI", 11f);
            txtCurrent.PasswordChar = '●';
            txtCurrent.BackColor = UIStyleHelper.SecondaryBg;
            txtCurrent.ForeColor = UIStyleHelper.PrimaryText;
            txtCurrent.BorderStyle = BorderStyle.FixedSingle;

            lblNew.Text = "Yeni PIN:";
            lblNew.ForeColor = UIStyleHelper.SecondaryText;
            lblNew.Font = new Font("Segoe UI", 9.5f);
            lblNew.Location = new Point(20, 94);
            lblNew.Size = new Size(120, 22);

            txtNew.Location = new Point(150, 92);
            txtNew.Size = new Size(240, 24);
            txtNew.Font = new Font("Segoe UI", 11f);
            txtNew.PasswordChar = '●';
            txtNew.BackColor = UIStyleHelper.SecondaryBg;
            txtNew.ForeColor = UIStyleHelper.PrimaryText;
            txtNew.BorderStyle = BorderStyle.FixedSingle;

            lblConfirm.Text = "Yeni PIN (tekrar):";
            lblConfirm.ForeColor = UIStyleHelper.SecondaryText;
            lblConfirm.Font = new Font("Segoe UI", 9.5f);
            lblConfirm.Location = new Point(20, 128);
            lblConfirm.Size = new Size(120, 22);

            txtConfirm.Location = new Point(150, 126);
            txtConfirm.Size = new Size(240, 24);
            txtConfirm.Font = new Font("Segoe UI", 11f);
            txtConfirm.PasswordChar = '●';
            txtConfirm.BackColor = UIStyleHelper.SecondaryBg;
            txtConfirm.ForeColor = UIStyleHelper.PrimaryText;
            txtConfirm.BorderStyle = BorderStyle.FixedSingle;

            lblIdle.Text = "Kilitlenme süresi:";
            lblIdle.ForeColor = UIStyleHelper.SecondaryText;
            lblIdle.Font = new Font("Segoe UI", 9.5f);
            lblIdle.Location = new Point(20, 166);
            lblIdle.Size = new Size(140, 22);

            cmbIdle.Location = new Point(170, 164);
            cmbIdle.Size = new Size(120, 24);
            cmbIdle.FlatStyle = FlatStyle.Flat;
            cmbIdle.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbIdle.BackColor = UIStyleHelper.SecondaryBg;
            cmbIdle.ForeColor = UIStyleHelper.PrimaryText;
            cmbIdle.Font = new Font("Segoe UI", 9.5f);
            cmbIdle.Items.AddRange(new object[] { "5 dk", "10 dk", "30 dk", "60 dk" });
            cmbIdle.SelectedIndex = 1;

            lblStatus.Text = "";
            lblStatus.ForeColor = UIStyleHelper.AccentGreen;
            lblStatus.Font = new Font("Segoe UI", 9.5f);
            lblStatus.AutoSize = false;
            lblStatus.Location = new Point(20, 200);
            lblStatus.Size = new Size(400, 22);

            btnApply.Text = "PIN'i Etkinleştir / Değiştir";
            btnApply.Location = new Point(20, 234);
            btnApply.Size = new Size(190, 36);
            UIStyleHelper.ApplyButtonTheme(btnApply, UIStyleHelper.AccentBlue, Color.White);
            btnApply.Click += BtnApply_Click;

            btnDisable.Text = "PIN'i Kapat";
            btnDisable.Location = new Point(225, 234);
            btnDisable.Size = new Size(190, 36);
            UIStyleHelper.ApplyButtonTheme(btnDisable, UIStyleHelper.AccentBg, UIStyleHelper.PrimaryText);
            btnDisable.Click += BtnDisable_Click;

            btnClose.Text = "Kapat";
            btnClose.Location = new Point(150, 284);
            btnClose.Size = new Size(140, 32);
            UIStyleHelper.ApplyButtonTheme(btnClose, UIStyleHelper.AccentBg, UIStyleHelper.SecondaryText);
            btnClose.Click += (s, e) => this.Close();

            this.Controls.Add(lblTitle);
            this.Controls.Add(lblCurrent);
            this.Controls.Add(txtCurrent);
            this.Controls.Add(lblNew);
            this.Controls.Add(txtNew);
            this.Controls.Add(lblConfirm);
            this.Controls.Add(txtConfirm);
            this.Controls.Add(lblIdle);
            this.Controls.Add(cmbIdle);
            this.Controls.Add(lblStatus);
            this.Controls.Add(btnApply);
            this.Controls.Add(btnDisable);
            this.Controls.Add(btnClose);
        }

        private void LoadCurrentValues()
        {
            bool enabled = SecurityService.IsPinEnabled();
            lblCurrent.Visible = enabled;
            txtCurrent.Visible = enabled;
            btnApply.Text = enabled ? "PIN'i Değiştir" : "PIN'i Etkinleştir";
            btnDisable.Enabled = enabled;
            int mins = SecurityService.GetIdleTimeoutMinutes();
            cmbIdle.SelectedIndex = mins switch
            {
                5 => 0,
                30 => 2,
                60 => 3,
                _ => 1
            };
        }

        private int GetSelectedIdleMinutes()
        {
            string? selected = cmbIdle.SelectedItem?.ToString();
            if (selected != null && int.TryParse(selected.Split(' ')[0], out int mins))
                return mins;
            return 10;
        }

        private void BtnApply_Click(object? sender, EventArgs e)
        {
            if (SecurityService.IsPinEnabled())
            {
                if (string.IsNullOrEmpty(txtCurrent.Text) || !SecurityService.VerifyPin(txtCurrent.Text))
                {
                    lblStatus.ForeColor = UIStyleHelper.AccentRed;
                    lblStatus.Text = "Mevcut PIN hatalı.";
                    return;
                }
            }

            string newPin = txtNew.Text;
            if (newPin.Length < 4)
            {
                lblStatus.ForeColor = UIStyleHelper.AccentRed;
                lblStatus.Text = "PIN en az 4 karakter olmalı.";
                return;
            }
            if (newPin != txtConfirm.Text)
            {
                lblStatus.ForeColor = UIStyleHelper.AccentRed;
                lblStatus.Text = "Yeni PIN alanları eşleşmiyor.";
                return;
            }

            SecurityService.SetPin(newPin);
            SecurityService.SetIdleTimeoutMinutes(GetSelectedIdleMinutes());

            lblStatus.ForeColor = UIStyleHelper.AccentGreen;
            lblStatus.Text = "PIN güncellendi ve etkinleştirildi.";
            ClearFields();
            LoadCurrentValues();
        }

        private void BtnDisable_Click(object? sender, EventArgs e)
        {
            if (!SecurityService.IsPinEnabled())
            {
                lblStatus.ForeColor = UIStyleHelper.AccentRed;
                lblStatus.Text = "PIN zaten devre dışı.";
                return;
            }

            if (string.IsNullOrEmpty(txtCurrent.Text) || !SecurityService.VerifyPin(txtCurrent.Text))
            {
                lblStatus.ForeColor = UIStyleHelper.AccentRed;
                lblStatus.Text = "Doğrulama için mevcut PIN gerekli.";
                return;
            }

            SecurityService.SetIdleTimeoutMinutes(GetSelectedIdleMinutes());
            SecurityService.DisablePin();

            lblStatus.ForeColor = UIStyleHelper.AccentGreen;
            lblStatus.Text = "PIN kapatıldı. Açılışta artık sorulmayacak.";
            ClearFields();
            LoadCurrentValues();
        }

        private void ClearFields()
        {
            txtCurrent.Clear();
            txtNew.Clear();
            txtConfirm.Clear();
        }
    }
}
