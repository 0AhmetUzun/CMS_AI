using System;
using System.Drawing;
using System.Windows.Forms;
using ContractManagementSystem_CMS_.Extensions;
using ContractManagementSystem_CMS_.Services;

namespace ContractManagementSystem_CMS_.Forms
{
    public partial class PinSetupForm : Form
    {
        public PinSetupForm()
        {
            InitializeComponent();
            ApplyButtonThemes();
            LoadCurrentValues();
        }

        private void ApplyButtonThemes()
        {
            UIStyleHelper.ApplyButtonTheme(btnApply, UIStyleHelper.AccentBlue, Color.White);
            UIStyleHelper.ApplyButtonTheme(btnDisable, UIStyleHelper.AccentBg, UIStyleHelper.PrimaryText);
            UIStyleHelper.ApplyButtonTheme(btnClose, UIStyleHelper.AccentBg, UIStyleHelper.SecondaryText);
        }

        private void BtnClose_Click(object? sender, EventArgs e)
        {
            this.Close();
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
