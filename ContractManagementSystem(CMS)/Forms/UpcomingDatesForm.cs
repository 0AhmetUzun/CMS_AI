using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using ContractManagementSystem_CMS_.Extensions;
using ContractManagementSystem_CMS_.Models;

namespace ContractManagementSystem_CMS_.Forms
{
    public partial class UpcomingDatesForm : Form
    {
        public UpcomingDatesForm()
        {
            InitializeComponent();
            StyleControls();
        }

        public UpcomingDatesForm(List<ContractDate> dates) : this()
        {
            Populate(dates);
        }

        private void StyleControls()
        {
            UIStyleHelper.ApplyButtonTheme(btnOk, UIStyleHelper.AccentBlue, Color.White);
        }

        private void Populate(List<ContractDate> dates)
        {
            header.Text = $"Önümüzdeki günlerde {dates.Count} kritik tarih yaklaşıyor:";

            int y = 10;
            foreach (var d in dates)
            {
                int days = d.DaysRemaining;
                Color accent = d.IsPast ? UIStyleHelper.AccentRed : (days <= 7 ? UIStyleHelper.AccentOrange : UIStyleHelper.AccentGreen);

                var row = new Panel
                {
                    Location = new Point(10, y),
                    Size = new Size(496, 56),
                    BackColor = UIStyleHelper.CardBg,
                    BorderStyle = BorderStyle.FixedSingle
                };

                var strip = new Panel { Location = new Point(0, 0), Size = new Size(6, 56), BackColor = accent };
                row.Controls.Add(strip);

                var lblMain = new Label
                {
                    Text = $"{d.DateTypeDisplayName} — {d.ContractName}",
                    ForeColor = UIStyleHelper.PrimaryText,
                    Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                    Location = new Point(16, 8),
                    Size = new Size(470, 18),
                    AutoEllipsis = true
                };
                row.Controls.Add(lblMain);

                var lblSub = new Label
                {
                    Text = $"📆 {d.DateValue.ToString("dd MMMM yyyy", new CultureInfo("tr-TR"))}  •  " +
                           (d.IsPast ? $"⚠ {Math.Abs(days)} gün geçti" : $"⏳ {days} gün kaldı"),
                    ForeColor = accent,
                    Font = new Font("Segoe UI", 9.5f),
                    Location = new Point(16, 30),
                    Size = new Size(470, 18)
                };
                row.Controls.Add(lblSub);

                panel.Controls.Add(row);
                y += 64;
            }
        }
    }
}
