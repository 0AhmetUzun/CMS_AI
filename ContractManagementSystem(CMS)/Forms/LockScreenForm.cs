using System;
using System.Drawing;
using System.Windows.Forms;
using ContractManagementSystem_CMS_.Extensions;
using ContractManagementSystem_CMS_.Services;

namespace ContractManagementSystem_CMS_.Forms
{
    public enum LockMode
    {
        Startup,
        Idle
    }

    public partial class LockScreenForm : Form
    {
        private readonly LockMode _mode;
        private TextBox txtPin = new TextBox();
        private Button btnUnlock = new Button();
        private Button btnCancel = new Button();
        private Label lblTitle = new Label();
        private Label lblInfo = new Label();
        private Label lblError = new Label();
        private int _failedAttempts = 0;

        public LockScreenForm(LockMode mode)
        {
            _mode = mode;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "CMS - Kilit Ekranı";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(420, 260);
            this.BackColor = UIStyleHelper.PrimaryBg;

            lblTitle.Text = "🔒 Sözleşme Yönetim Sistemi";
            lblTitle.Font = new Font("Segoe UI", 14f, FontStyle.Bold);
            lblTitle.ForeColor = UIStyleHelper.PrimaryText;
            lblTitle.AutoSize = false;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Location = new Point(20, 20);
            lblTitle.Size = new Size(380, 30);

            lblInfo.Text = _mode == LockMode.Idle
                ? "Oturum boşta kaldığı için kilitlendi. Devam etmek için PIN girin."
                : "Uygulamayı açmak için PIN girin.";
            lblInfo.Font = new Font("Segoe UI", 9.5f);
            lblInfo.ForeColor = UIStyleHelper.SecondaryText;
            lblInfo.AutoSize = false;
            lblInfo.TextAlign = ContentAlignment.MiddleCenter;
            lblInfo.Location = new Point(20, 56);
            lblInfo.Size = new Size(380, 36);

            txtPin.Location = new Point(60, 100);
            txtPin.Size = new Size(280, 26);
            txtPin.Font = new Font("Segoe UI", 12f);
            txtPin.PasswordChar = '●';
            txtPin.BackColor = UIStyleHelper.SecondaryBg;
            txtPin.ForeColor = UIStyleHelper.PrimaryText;
            txtPin.BorderStyle = BorderStyle.FixedSingle;
            txtPin.KeyDown += TxtPin_KeyDown;

            lblError.Text = "";
            lblError.Font = new Font("Segoe UI", 9f);
            lblError.ForeColor = UIStyleHelper.AccentRed;
            lblError.AutoSize = false;
            lblError.TextAlign = ContentAlignment.MiddleCenter;
            lblError.Location = new Point(20, 132);
            lblError.Size = new Size(380, 22);

            btnUnlock.Text = "Kilidi Aç";
            btnUnlock.Location = new Point(60, 162);
            btnUnlock.Size = new Size(135, 36);
            UIStyleHelper.ApplyButtonTheme(btnUnlock, UIStyleHelper.AccentBlue, Color.White);
            btnUnlock.Click += BtnUnlock_Click;

            btnCancel.Text = "Çıkış";
            btnCancel.Location = new Point(205, 162);
            btnCancel.Size = new Size(135, 36);
            UIStyleHelper.ApplyButtonTheme(btnCancel, UIStyleHelper.AccentBg, UIStyleHelper.PrimaryText);
            btnCancel.Click += BtnCancel_Click;

            this.Controls.Add(lblTitle);
            this.Controls.Add(lblInfo);
            this.Controls.Add(txtPin);
            this.Controls.Add(lblError);
            this.Controls.Add(btnUnlock);
            this.Controls.Add(btnCancel);

            this.AcceptButton = btnUnlock;
            this.CancelButton = btnCancel;
        }

        private void TxtPin_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                TryUnlock();
            }
        }

        private void BtnUnlock_Click(object? sender, EventArgs e)
        {
            TryUnlock();
        }

        private void TryUnlock()
        {
            string pin = txtPin.Text;
            if (string.IsNullOrEmpty(pin))
            {
                lblError.Text = "Lütfen PIN girin.";
                return;
            }

            if (SecurityService.VerifyPin(pin))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                _failedAttempts++;
                txtPin.Clear();
                if (_failedAttempts >= 3)
                {
                    lblError.Text = "Çok fazla hatalı deneme. Uygulama kapatılıyor.";
                    btnUnlock.Enabled = false;
                    txtPin.Enabled = false;
                    System.Windows.Forms.Timer t = new System.Windows.Forms.Timer { Interval = 1200 };
                    t.Tick += (s, e) => { t.Dispose(); this.DialogResult = DialogResult.Cancel; this.Close(); };
                    t.Start();
                }
                else
                {
                    lblError.Text = "Hatalı PIN. Tekrar deneyin.";
                }
            }
        }

        private void BtnCancel_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
