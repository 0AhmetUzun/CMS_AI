using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ContractManagementSystem_CMS_.Extensions;
using ContractManagementSystem_CMS_.Models;
using ContractManagementSystem_CMS_.Services;

namespace ContractManagementSystem_CMS_.Forms
{
    public partial class DateManagementForm : Form
    {
        private readonly DateReminderService _dateService;
        private ContractDate? _selectedDate;

        public DateManagementForm()
        {
            _dateService = new DateReminderService();
            InitializeComponent();
            SetupToolbar();
            _flpCards.Click += (s, e) => ClearSelection();
            UIStyleHelper.ApplyModernTableTheme(_dgvMonth);
            LoadDates(7);
        }

        private void SetupToolbar()
        {
            int x = 70;
            var filters = new (string text, int days)[] { ("Yarın", 1), ("3 Gün", 3), ("7 Gün", 7), ("Bu Ay", DaysUntilEndOfMonth()), ("Tümü", 3650) };
            foreach (var (text, days) in filters)
            {
                var btn = new Button { Text = text, Tag = days, Location = new Point(x, 12), Size = new Size(70, 32) };
                UIStyleHelper.ApplyButtonTheme(btn, UIStyleHelper.AccentBg, UIStyleHelper.PrimaryText);
                btn.Click += (s, e) => LoadDates((int)((Button)s!).Tag!);
                topPanel.Controls.Add(btn);
                x += 78;
            }

            var btnAdd = new Button { Text = "➕ Tarih Ekle", Location = new Point(x + 10, 12), Size = new Size(110, 32) };
            UIStyleHelper.ApplyButtonTheme(btnAdd, UIStyleHelper.AccentGreen, Color.White);
            btnAdd.Click += BtnAdd_Click;
            topPanel.Controls.Add(btnAdd);

            var btnEdit = new Button { Text = "✏️ Düzenle", Location = new Point(x + 130, 12), Size = new Size(95, 32) };
            UIStyleHelper.ApplyButtonTheme(btnEdit, UIStyleHelper.AccentBg, UIStyleHelper.PrimaryText);
            btnEdit.Click += BtnEdit_Click;
            topPanel.Controls.Add(btnEdit);

            var btnDelete = new Button { Text = "🗑️ Sil", Location = new Point(x + 235, 12), Size = new Size(85, 32) };
            UIStyleHelper.ApplyButtonTheme(btnDelete, UIStyleHelper.AccentRed, Color.White);
            btnDelete.Click += BtnDelete_Click;
            topPanel.Controls.Add(btnDelete);
        }

        private static int DaysUntilEndOfMonth()
        {
            var today = DateTime.Today;
            var end = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));
            return Math.Max(1, (end - today).Days);
        }

        private void LoadDates(int withinDays)
        {
            _selectedDate = null;
            var dates = _dateService.GetUpcomingDates(withinDays, includePast: withinDays >= 3650);

            // Kartlar
            _flpCards.Controls.Clear();
            if (dates.Count == 0)
            {
                var empty = new Label
                {
                    Text = "Yaklaşan tarih bulunamadı.",
                    ForeColor = UIStyleHelper.MutedText,
                    AutoSize = true,
                    Margin = new Padding(10)
                };
                _flpCards.Controls.Add(empty);
            }
            foreach (var d in dates)
            {
                _flpCards.Controls.Add(CreateCard(d));
            }

            // Aylık liste
            _dgvMonth.Rows.Clear();
            _dgvMonth.Columns.Clear();
            _dgvMonth.Columns.Add("Id", "Id");
            _dgvMonth.Columns["Id"].Visible = false;
            _dgvMonth.Columns.Add("Sozlesme", "Sözleşme");
            _dgvMonth.Columns.Add("Turu", "Türü");
            _dgvMonth.Columns.Add("Tarih", "Tarih");
            _dgvMonth.Columns.Add("Kalan", "Kalan Gün");
            _dgvMonth.Columns.Add("Hatirlatma", "Hatırlatma (gün)");
            _dgvMonth.Columns.Add("Not", "Not");

            foreach (var d in dates)
            {
                int row = _dgvMonth.Rows.Add(d.Id, d.ContractName, d.DateTypeDisplayName,
                    d.DateValue.ToString("dd.MM.yyyy"), d.DaysRemaining, d.ReminderDays, d.Note);
                var cell = _dgvMonth.Rows[row].Cells["Kalan"];
                cell.Style.ForeColor = d.IsPast ? UIStyleHelper.AccentRed : (d.DaysRemaining <= 7 ? UIStyleHelper.AccentOrange : UIStyleHelper.AccentGreen);
            }
            _dgvMonth.AutoResizeColumns();
        }

        private Panel CreateCard(ContractDate d)
        {
            int days = d.DaysRemaining;
            Color accent = d.IsPast ? UIStyleHelper.AccentRed : (days <= 7 ? UIStyleHelper.AccentOrange : UIStyleHelper.AccentGreen);

            var card = new Panel
            {
                Width = 300,
                Height = 132,
                Margin = new Padding(8),
                BackColor = UIStyleHelper.CardBg,
                BorderStyle = BorderStyle.FixedSingle,
                Tag = d,
                Cursor = Cursors.Hand
            };

            var strip = new Panel { Dock = DockStyle.Left, Width = 6, BackColor = accent };
            card.Controls.Add(strip);

            var lblType = new Label
            {
                Text = d.DateTypeDisplayName,
                ForeColor = UIStyleHelper.PrimaryText,
                Font = new Font("Segoe UI", 10.5f, FontStyle.Bold),
                Location = new Point(16, 10),
                AutoSize = true
            };
            card.Controls.Add(lblType);

            var lblContract = new Label
            {
                Text = d.ContractName ?? "(Bilinmiyor)",
                ForeColor = UIStyleHelper.SecondaryText,
                Font = new Font("Segoe UI", 9f),
                Location = new Point(16, 34),
                Size = new Size(270, 18),
                AutoEllipsis = true
            };
            card.Controls.Add(lblContract);

            var lblDate = new Label
            {
                Text = "📆 " + d.DateValue.ToString("dd MMMM yyyy", new System.Globalization.CultureInfo("tr-TR")),
                ForeColor = UIStyleHelper.PrimaryText,
                Font = new Font("Segoe UI", 10f),
                Location = new Point(16, 58),
                AutoSize = true
            };
            card.Controls.Add(lblDate);

            var lblDays = new Label
            {
                Text = d.IsPast ? $"⏱ {Math.Abs(days)} gün geçti" : $"⏳ {days} gün kaldı",
                ForeColor = accent,
                Font = new Font("Segoe UI", 11f, FontStyle.Bold),
                Location = new Point(16, 84),
                AutoSize = true
            };
            card.Controls.Add(lblDays);

            var lblNote = new Label
            {
                Text = string.IsNullOrWhiteSpace(d.Note) ? "" : "📝 " + d.Note,
                ForeColor = UIStyleHelper.MutedText,
                Font = new Font("Segoe UI", 8.5f),
                Location = new Point(16, 108),
                Size = new Size(270, 18),
                AutoEllipsis = true
            };
            card.Controls.Add(lblNote);

            card.Click += (s, e) => SelectCard(card, d);
            foreach (Control c in card.Controls)
                c.Click += (s, e) => SelectCard(card, d);

            return card;
        }

        private void SelectCard(Panel card, ContractDate d)
        {
            _selectedDate = d;
            foreach (Control c in _flpCards.Controls)
            {
                if (c is Panel p)
                    p.BackColor = UIStyleHelper.CardBg;
            }
            card.BackColor = UIStyleHelper.HoverColor;
        }

        private void ClearSelection()
        {
            _selectedDate = null;
            foreach (Control c in _flpCards.Controls)
            {
                if (c is Panel p)
                    p.BackColor = UIStyleHelper.CardBg;
            }
        }

        private void DgvMonth_SelectionChanged(object? sender, EventArgs e)
        {
            if (_dgvMonth.SelectedRows.Count > 0)
            {
                var row = _dgvMonth.SelectedRows[0];
                int id = (int)row.Cells["Id"].Value;
                _selectedDate = _dateService.GetAllDates().FirstOrDefault(x => x.Id == id);
            }
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            var contracts = _dateService.GetAllContracts();
            if (contracts.Count == 0)
            {
                MessageBox.Show("Önce en az bir sözleşme yüklemelisiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var edit = ShowEditDialog(new ContractDate { DateValue = DateTime.Today, ReminderDays = 30 }, contracts, isNew: true);
            if (edit != null)
            {
                _dateService.AddManualDate(edit);
                LoadDates(7);
            }
        }

        private void BtnEdit_Click(object? sender, EventArgs e)
        {
            if (_selectedDate == null)
            {
                MessageBox.Show("Lütfen düzenlenecek bir tarih seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var contracts = _dateService.GetAllContracts();
            var edit = ShowEditDialog(_selectedDate, contracts, isNew: false);
            if (edit != null)
            {
                _dateService.UpdateDate(edit);
                LoadDates(7);
            }
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (_selectedDate == null)
            {
                MessageBox.Show("Lütfen silinecek bir tarih seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Seçili tarih silinsin mi?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _dateService.DeleteDate(_selectedDate.Id);
                LoadDates(7);
            }
        }

        private ContractDate? ShowEditDialog(ContractDate source, List<ContractListItem> contracts, bool isNew)
        {
            using var dlg = new Form
            {
                Text = isNew ? "Yeni Tarih Ekle" : "Tarihi Düzenle",
                Size = new Size(420, 320),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = UIStyleHelper.PrimaryBg,
                ForeColor = UIStyleHelper.PrimaryText,
                Font = new Font("Segoe UI", 10f)
            };

            var lblContract = new Label { Text = "Sözleşme:", Location = new Point(20, 20), AutoSize = true, ForeColor = UIStyleHelper.SecondaryText };
            var cmbContract = new ComboBox { Location = new Point(140, 16), Width = 240, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbContract.DataSource = contracts;
            cmbContract.DisplayMember = "FileName";
            cmbContract.ValueMember = "Id";
            if (!isNew) cmbContract.SelectedValue = source.ContractId;

            var lblType = new Label { Text = "Tür:", Location = new Point(20, 56), AutoSize = true, ForeColor = UIStyleHelper.SecondaryText };
            var cmbType = new ComboBox { Location = new Point(140, 52), Width = 240, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbType.Items.AddRange(new object[] { "Bitis", "FesihBildirim", "Odeme", "Yenileme" });
            cmbType.SelectedItem = source.DateType;

            var lblDate = new Label { Text = "Tarih:", Location = new Point(20, 92), AutoSize = true, ForeColor = UIStyleHelper.SecondaryText };
            var dtp = new DateTimePicker { Location = new Point(140, 88), Width = 240, Value = source.DateValue, Format = DateTimePickerFormat.Short };

            var lblReminder = new Label { Text = "Hatırlatma (gün):", Location = new Point(20, 128), AutoSize = true, ForeColor = UIStyleHelper.SecondaryText };
            var numReminder = new NumericUpDown { Location = new Point(140, 124), Width = 100, Minimum = 0, Maximum = 365, Value = source.ReminderDays };

            var lblNote = new Label { Text = "Not:", Location = new Point(20, 164), AutoSize = true, ForeColor = UIStyleHelper.SecondaryText };
            var txtNote = new TextBox { Location = new Point(140, 160), Width = 240, Text = source.Note ?? "" };

            var btnOk = new Button { Text = "Kaydet", Location = new Point(140, 230), Width = 110, DialogResult = DialogResult.OK };
            UIStyleHelper.ApplyButtonTheme(btnOk, UIStyleHelper.AccentGreen, Color.White);
            var btnCancel = new Button { Text = "İptal", Location = new Point(270, 230), Width = 110, DialogResult = DialogResult.Cancel };
            UIStyleHelper.ApplyButtonTheme(btnCancel, UIStyleHelper.AccentBg, UIStyleHelper.PrimaryText);

            dlg.Controls.AddRange(new Control[] { lblContract, cmbContract, lblType, cmbType, lblDate, dtp, lblReminder, numReminder, lblNote, txtNote, btnOk, btnCancel });
            dlg.AcceptButton = btnOk;
            dlg.CancelButton = btnCancel;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                return new ContractDate
                {
                    Id = source.Id,
                    ContractId = (int)cmbContract.SelectedValue!,
                    DateType = cmbType.SelectedItem?.ToString() ?? "Bitis",
                    DateValue = dtp.Value.Date,
                    ReminderDays = (int)numReminder.Value,
                    Note = txtNote.Text.Trim()
                };
            }
            return null;
        }
    }
}
