using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using ContractManagementSystem_CMS_.Services;

namespace ContractManagementSystem_CMS_.Extensions
{
    public static class RichTextBoxExtensions
    {
        public static void ClearHighlights(this RichTextBox rtb)
        {
            int currentPos = rtb.SelectionStart;
            string? rtf = rtb.Rtf;
            rtb.Clear();
            if (rtf != null) rtb.Rtf = rtf;
            rtb.SelectionStart = currentPos;
        }

        public static void HighlightPattern(this RichTextBox rtb, string word, Color color)
        {
            if (string.IsNullOrEmpty(word) || color == Color.Empty) return;

            string text = rtb.Text;
            CompareInfo trCompare = CultureInfo.GetCultureInfo("tr-TR").CompareInfo;
            int index = 0;

            rtb.SuspendLayout();

            while (index < text.Length)
            {
                index = trCompare.IndexOf(text, word, index, CompareOptions.IgnoreCase);
                if (index == -1) break;

                rtb.Select(index, word.Length);
                rtb.SelectionBackColor = color;
                index += word.Length;
            }

            rtb.DeselectAll();
            rtb.ResumeLayout();
        }

        public static void EnableDragDrop(this RichTextBox rtb)
        {
            rtb.AllowDrop = true;
            rtb.DragEnter += (sender, e) =>
            {
                if (e.Data?.GetDataPresent(DataFormats.FileDrop) == true) e.Effect = DragDropEffects.Copy;
                else e.Effect = DragDropEffects.None;
            };
            rtb.DragDrop += (sender, e) =>
            {
                var data = e.Data?.GetData(DataFormats.FileDrop);
                if (data is string[] files && files.Length > 0 && Path.GetExtension(files[0]).ToLower() == ".docx")
                {
                    try { rtb.Text = WordDocumentHelper.ReadParagraphsOnly(files[0]); }
                    catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
                }
            };
        }

    }
}