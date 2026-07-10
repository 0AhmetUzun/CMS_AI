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
    public partial class ChangesSummaryForm : Form
    {
        private readonly List<ExtractionChangeLog> _changes;
        private readonly string _contractName;
        private readonly int _contractId;
        private readonly ExtractionService _extractionService;
        private List<ExtractionChangeLog> _undoneChanges = new();

        public ChangesSummaryForm(List<ExtractionChangeLog> changes, string contractName, int contractId)
        {
            InitializeComponent();
            _changes = changes;
            _contractName = contractName;
            _contractId = contractId;
            _extractionService = new ExtractionService();

            ApplyTheme();
            LoadChanges();
        }

        private void ApplyTheme()
        {
            this.BackColor = UIStyleHelper.PrimaryBg;
            this.ForeColor = UIStyleHelper.PrimaryText;

            lblTitle.ForeColor = UIStyleHelper.AccentBlue;
            lblContractName.ForeColor = UIStyleHelper.PrimaryText;
            lblDate.ForeColor = UIStyleHelper.SecondaryText;
            lblChangedCount.ForeColor = UIStyleHelper.AccentOrange;

            btnConfirm.BackColor = UIStyleHelper.AccentGreen;
            btnConfirm.ForeColor = Color.White;
            btnConfirm.FlatStyle = FlatStyle.Flat;
            btnConfirm.FlatAppearance.BorderSize = 0;

            btnUndoAll.BackColor = UIStyleHelper.AccentOrange;
            btnUndoAll.ForeColor = Color.White;
            btnUndoAll.FlatStyle = FlatStyle.Flat;
            btnUndoAll.FlatAppearance.BorderSize = 0;

            btnCancel.BackColor = UIStyleHelper.AccentBg;
            btnCancel.ForeColor = UIStyleHelper.PrimaryText;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderColor = UIStyleHelper.BorderColor;
        }

        private void LoadChanges()
        {
            lblContractName.Text = $"📄 {_contractName}";
            lblDate.Text = $"📅 {DateTime.Now:dd.MM.yyyy HH:mm}";
            
            var changedItems = _changes.Where(c => c.IsChanged).ToList();
            var unchangedItems = _changes.Where(c => !c.IsChanged).ToList();
            
            lblChangedCount.Text = $"⚠️ {changedItems.Count} alan değiştirildi";

            flowChanged.Controls.Clear();
            flowUnchanged.Controls.Clear();

            foreach (var change in changedItems)
            {
                var card = CreateChangeCard(change, true);
                flowChanged.Controls.Add(card);
            }

            foreach (var change in unchangedItems)
            {
                var card = CreateChangeCard(change, false);
                flowUnchanged.Controls.Add(card);
            }

            if (unchangedItems.Count == 0)
            {
                lblUnchangedTitle.Visible = false;
                flowUnchanged.Visible = false;
            }
        }

        private Panel CreateChangeCard(ExtractionChangeLog change, bool isChanged)
        {
            var panel = new Panel
            {
                Size = new Size(680, isChanged ? 100 : 50),
                BackColor = isChanged ? UIStyleHelper.CardBg : UIStyleHelper.SecondaryBg,
                Padding = new Padding(10),
                Margin = new Padding(0, 0, 0, 5)
            };

            var lblFieldName = new Label
            {
                Text = _extractionService.GetFieldDisplayName(change.FieldName),
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                ForeColor = isChanged ? UIStyleHelper.AccentBlue : UIStyleHelper.SecondaryText,
                Location = new Point(10, 5),
                AutoSize = true
            };
            panel.Controls.Add(lblFieldName);

            if (isChanged)
            {
                var lblOldValue = new Label
                {
                    Text = $"Önceki: {change.OldValue}",
                    Font = new Font("Segoe UI", 9f),
                    ForeColor = UIStyleHelper.AccentRed,
                    Location = new Point(10, 30),
                    AutoSize = true
                };
                panel.Controls.Add(lblOldValue);

                var lblNewValue = new Label
                {
                    Text = $"Yeni: {change.NewValue}",
                    Font = new Font("Segoe UI", 9f),
                    ForeColor = UIStyleHelper.AccentGreen,
                    Location = new Point(10, 50),
                    AutoSize = true
                };
                panel.Controls.Add(lblNewValue);

                var btnUndo = new Button
                {
                    Text = "↩️ Geri Al",
                    Size = new Size(80, 25),
                    Location = new Point(600, 35),
                    BackColor = UIStyleHelper.AccentBg,
                    ForeColor = UIStyleHelper.PrimaryText,
                    FlatStyle = FlatStyle.Flat,
                    FlatAppearance = { BorderColor = UIStyleHelper.BorderColor, BorderSize = 1 },
                    Cursor = Cursors.Hand,
                    Tag = change
                };
                btnUndo.Click += BtnUndo_Click;
                panel.Controls.Add(btnUndo);
            }
            else
            {
                var lblValue = new Label
                {
                    Text = $"Değer: {change.NewValue}",
                    Font = new Font("Segoe UI", 9f),
                    ForeColor = UIStyleHelper.SecondaryText,
                    Location = new Point(10, 28),
                    AutoSize = true
                };
                panel.Controls.Add(lblValue);
            }

            return panel;
        }

        private void BtnUndo_Click(object? sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is ExtractionChangeLog change)
            {
                var result = MessageBox.Show(
                    $"'{change.FieldName}' alanını eski değerine ({change.OldValue}) döndürmek istediğinize emin misiniz?",
                    "Geri Alma Onayı",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        _extractionService.UndoChange(change.ExtractionId);
                        _undoneChanges.Add(change);
                        
                        MessageBox.Show(
                            $"'{change.FieldName}' alanı başarıyla geri alındı.",
                            "Başarılı",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        LoadChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            $"Geri alma işlemi sırasında hata oluştu: {ex.Message}",
                            "Hata",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnUndoAll_Click(object sender, EventArgs e)
        {
            var changedItems = _changes.Where(c => c.IsChanged && !_undoneChanges.Any(u => u.FieldName == c.FieldName)).ToList();
            
            if (changedItems.Count == 0)
            {
                MessageBox.Show("Geri alınacak değişiklik bulunmuyor.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show(
                $"{changedItems.Count} değişikliğin tamamını geri almak istediğinize emin misiniz?",
                "Tümünü Geri Al Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    foreach (var change in changedItems)
                    {
                        _extractionService.UndoChange(change.ExtractionId);
                        _undoneChanges.Add(change);
                    }

                    MessageBox.Show(
                        $"{changedItems.Count} değişiklik başarıyla geri alındı.",
                        "Başarılı",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Geri alma işlemi sırasında hata oluştu: {ex.Message}",
                        "Hata",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
