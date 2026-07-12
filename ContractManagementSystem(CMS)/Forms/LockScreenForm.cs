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
        private int _failedAttempts = 0;

        public LockScreenForm()
        {
            InitializeComponent();
            UIStyleHelper.ApplyButtonTheme(btnUnlock, UIStyleHelper.AccentBlue, Color.White);
            UIStyleHelper.ApplyButtonTheme(btnCancel, UIStyleHelper.AccentBg, UIStyleHelper.PrimaryText);
        }

        public LockScreenForm(LockMode mode) : this()
        {
            _mode = mode;
            lblInfo.Text = mode == LockMode.Idle
                ? "Oturum boşta kaldığı için kilitlendi. Devam etmek için PIN girin."
                : "Uygulamayı açmak için PIN girin.";
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
