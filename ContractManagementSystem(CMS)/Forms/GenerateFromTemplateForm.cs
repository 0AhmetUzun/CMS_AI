using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContractManagementSystem_CMS_.Extensions;
using ContractManagementSystem_CMS_.Models;
using ContractManagementSystem_CMS_.Services;

namespace ContractManagementSystem_CMS_.Forms
{
    public partial class GenerateFromTemplateForm : Form
    {
        private readonly TemplateService _templateService = new TemplateService();
        private readonly AIService _aiService = new AIService();
        private readonly ContractTemplate _template;
        private readonly Dictionary<string, TextBox> _fieldBoxes = new Dictionary<string, TextBox>();
        private Panel pnlFields = new Panel();
        private Button btnGenerate = new Button();
        private Button btnClose = new Button();
        private Label lblStatus = new Label();

        public GenerateFromTemplateForm(ContractTemplate template)
        {
            _template = template;
            InitializeComponent();
            ApplyTheme();
            BuildFields();
        }

        private void InitializeComponent()
        {
            this.Text = "Şablondan Sözleşme Üret: " + _template.TemplateName;
            this.Size = new Size(720, 600);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            pnlFields = new Panel
            {
                Location = new Point(12, 12),
                Size = new Size(680, 480),
                AutoScroll = true,
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(pnlFields);

            btnGenerate = new Button { Text = "📄 Oluştur (.docx)", Location = new Point(470, 504), Size = new Size(140, 34) };
            btnClose = new Button { Text = "Kapat", Location = new Point(620, 504), Size = new Size(80, 34) };
            lblStatus = new Label { Location = new Point(12, 510), Size = new Size(440, 24), ForeColor = UIStyleHelper.SecondaryText };

            btnGenerate.Click += BtnGenerate_Click;
            btnClose.Click += (s, e) => this.Close();

            this.Controls.Add(btnGenerate);
            this.Controls.Add(btnClose);
            this.Controls.Add(lblStatus);
        }

        private void ApplyTheme()
        {
            this.BackColor = UIStyleHelper.PrimaryBg;
            this.ForeColor = UIStyleHelper.PrimaryText;
            pnlFields.BackColor = UIStyleHelper.AccentBg;
            UIStyleHelper.ApplyButtonTheme(btnGenerate, UIStyleHelper.AccentTeal, Color.White);
            UIStyleHelper.ApplyButtonTheme(btnClose, UIStyleHelper.AccentBg, UIStyleHelper.PrimaryText);
        }

        private void BuildFields()
        {
            var placeholders = _templateService.ExtractPlaceholders(_template.Content);
            if (placeholders.Count == 0)
            {
                var lbl = new Label
                {
                    Text = "Bu şablonda doldurulacak alan ([[Alan]]) bulunamadı. Yine de olduğu gibi dışa aktarabilirsiniz.",
                    Location = new Point(10, 10),
                    Size = new Size(640, 40),
                    ForeColor = UIStyleHelper.SecondaryText
                };
                pnlFields.Controls.Add(lbl);
                return;
            }

            int y = 10;
            int rowHeight = 30;
            int gap = 8;
            foreach (var ph in placeholders)
            {
                var lbl = new Label
                {
                    Text = ph,
                    Location = new Point(10, y + 4),
                    Size = new Size(150, 22),
                    ForeColor = UIStyleHelper.PrimaryText,
                    Font = new Font("Segoe UI", 9f)
                };

                var txt = new TextBox
                {
                    Location = new Point(170, y),
                    Size = new Size(330, 22),
                    BackColor = UIStyleHelper.PrimaryBg,
                    ForeColor = UIStyleHelper.PrimaryText,
                    Font = new Font("Segoe UI", 9.5f)
                };

                var btnAi = new Button
                {
                    Text = "AI",
                    Location = new Point(510, y),
                    Size = new Size(40, 22),
                    Tag = ph,
                    Font = new Font("Segoe UI", 8.5f, FontStyle.Bold)
                };
                btnAi.Click += BtnAi_Click;
                UIStyleHelper.ApplyButtonTheme(btnAi, UIStyleHelper.AccentPurple, Color.White);

                pnlFields.Controls.Add(lbl);
                pnlFields.Controls.Add(txt);
                pnlFields.Controls.Add(btnAi);
                _fieldBoxes[ph] = txt;

                y += rowHeight + gap;
            }
        }

        private async void BtnAi_Click(object? sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is string placeholder)
            {
                string instruction = Microsoft.VisualBasic.Interaction.InputBox(
                    $"'{placeholder}' alanı için AI'dan madde taslağı isteyin (serbest Türkçe açıklama girin):",
                    "AI ile Madde Oluştur", "");

                if (string.IsNullOrWhiteSpace(instruction)) return;

                btn.Enabled = false;
                lblStatus.Text = "AI madde taslağı hazırlıyor...";
                try
                {
                    bool connected = await _aiService.CheckConnectionAsync();
                    if (!connected)
                    {
                        MessageBox.Show("Ollama bağlantısı yok. AI özelliği kullanılamıyor.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string draft = await _aiService.DraftClauseAsync(instruction);
                    if (_fieldBoxes.TryGetValue(placeholder, out var txt))
                    {
                        txt.Text = draft.Trim();
                        lblStatus.Text = "Öneri alana eklendi. İsterseniz düzenleyip kaydedebilirsiniz.";
                    }
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "AI hatası: " + ex.Message;
                }
                finally
                {
                    btn.Enabled = true;
                }
            }
        }

        private void BtnGenerate_Click(object? sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Word Belgesi (*.docx)|*.docx",
                FileName = SanitizeFileName(_template.TemplateName) + ".docx"
            })
            {
                if (sfd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    var fields = _fieldBoxes.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Text);
                    _templateService.GenerateDocument(_template.Id, fields, sfd.FileName);
                    MessageBox.Show("Sözleşme başarıyla oluşturuldu:\n" + sfd.FileName, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo { FileName = sfd.FileName, UseShellExecute = true });
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Belge oluşturulurken hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private static string SanitizeFileName(string name)
        {
            foreach (char c in Path.GetInvalidFileNameChars())
                name = name.Replace(c, '_');
            return name;
        }
    }
}
