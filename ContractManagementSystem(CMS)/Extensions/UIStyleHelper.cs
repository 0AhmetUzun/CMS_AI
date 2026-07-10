using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ContractManagementSystem_CMS_.Extensions
{
    public static class UIStyleHelper
    {
        public static readonly Color PrimaryBg = Color.FromArgb(30, 30, 30);
        public static readonly Color SecondaryBg = Color.FromArgb(40, 40, 40);
        public static readonly Color AccentBg = Color.FromArgb(50, 50, 50);
        public static readonly Color CardBg = Color.FromArgb(45, 45, 45);
        public static readonly Color SurfaceBg = Color.FromArgb(35, 35, 35);

        public static readonly Color PrimaryText = Color.FromArgb(240, 240, 240);
        public static readonly Color SecondaryText = Color.FromArgb(180, 180, 180);
        public static readonly Color MutedText = Color.FromArgb(120, 120, 120);

        public static readonly Color AccentBlue = Color.FromArgb(0, 120, 215);
        public static readonly Color AccentGreen = Color.FromArgb(40, 167, 69);
        public static readonly Color AccentRed = Color.FromArgb(220, 53, 69);
        public static readonly Color AccentOrange = Color.FromArgb(255, 152, 0);
        public static readonly Color AccentPurple = Color.FromArgb(128, 0, 255);
        public static readonly Color AccentTeal = Color.FromArgb(0, 184, 149);

        public static readonly Color BorderColor = Color.FromArgb(60, 60, 60);
        public static readonly Color HoverColor = Color.FromArgb(55, 55, 55);

        public static readonly Color RiskGreen = Color.FromArgb(40, 167, 69);
        public static readonly Color RiskYellow = Color.FromArgb(255, 193, 7);
        public static readonly Color RiskRed = Color.FromArgb(220, 53, 69);

        public static void ApplyButtonTheme(Button btn, Color? bgColor = null, Color? fgColor = null)
        {
            if (btn == null) return;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = BorderColor;
            btn.BackColor = bgColor ?? AccentBg;
            btn.ForeColor = fgColor ?? PrimaryText;
            btn.Font = new Font("Segoe UI", 9.5f, FontStyle.Regular);
            btn.Cursor = Cursors.Hand;
            btn.TextAlign = ContentAlignment.MiddleCenter;
            btn.Padding = new Padding(8, 0, 8, 0);
            btn.MouseEnter += (s, e) => { btn.BackColor = HoverColor; btn.FlatAppearance.BorderColor = AccentBlue; };
            btn.MouseLeave += (s, e) => { btn.BackColor = bgColor ?? AccentBg; btn.FlatAppearance.BorderColor = BorderColor; };
        }

        public static void ApplyModernTableTheme(DataGridView dgv)
        {
            if (dgv == null) return;
            dgv.EnableHeadersVisualStyles = false;
            dgv.BackgroundColor = SecondaryBg;
            dgv.BorderStyle = BorderStyle.None;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = AccentBg;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = PrimaryText;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = AccentBg;
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = PrimaryText;
            dgv.ColumnHeadersHeight = 40;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgv.DefaultCellStyle.BackColor = SecondaryBg;
            dgv.DefaultCellStyle.ForeColor = PrimaryText;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9.5f);
            dgv.DefaultCellStyle.SelectionBackColor = HoverColor;
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.DefaultCellStyle.Padding = new Padding(4);

            dgv.AlternatingRowsDefaultCellStyle.BackColor = CardBg;
            dgv.GridColor = BorderColor;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ClearSelection();
        }

        public static void SetScoreIndicatorColor(Panel pnl, int score)
        {
            if (pnl == null) return;
            if (score >= 75) pnl.BackColor = RiskGreen;
            else if (score >= 40) pnl.BackColor = RiskYellow;
            else pnl.BackColor = RiskRed;
        }
    }
}
