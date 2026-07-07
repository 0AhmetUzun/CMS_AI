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

        public static void HighlightWordAtPosition(this RichTextBox rtb, int position, int length, Color color)
        {
            if (position < 0 || length <= 0 || position + length > rtb.TextLength) return;

            rtb.SuspendLayout();
            rtb.Select(position, length);
            rtb.SelectionBackColor = color;
            rtb.DeselectAll();
            rtb.ResumeLayout();
        }

        public static void EnableDragDrop(this RichTextBox rtb, Action<string>? onFileDropped = null)
        {
            rtb.AllowDrop = true;

            rtb.DragEnter -= Rtb_DragEnter;
            rtb.DragDrop -= Rtb_DragDrop;

            rtb.Tag = onFileDropped;

            rtb.DragEnter += Rtb_DragEnter;
            rtb.DragDrop += Rtb_DragDrop;
        }

        private static void Rtb_DragEnter(object? sender, DragEventArgs e)
        {
            if (e.Data?.GetDataPresent(DataFormats.FileDrop) == true)
            {
                var data = e.Data.GetData(DataFormats.FileDrop) as string[];
                if (data != null && data.Length > 0)
                {
                    string ext = Path.GetExtension(data[0]).ToLower();
                    if (ext == ".docx" || ext == ".pdf")
                    {
                        e.Effect = DragDropEffects.Copy;
                        return;
                    }
                }
            }
            e.Effect = DragDropEffects.None;
        }

        private static void Rtb_DragDrop(object? sender, DragEventArgs e)
        {
            if (sender is not RichTextBox rtb) return;

            var data = e.Data?.GetData(DataFormats.FileDrop);
            if (data is string[] files && files.Length > 0)
            {
                string ext = Path.GetExtension(files[0]).ToLower();
                try
                {
                    string content = ext == ".docx"
                        ? WordDocumentHelper.ReadFullContent(files[0])
                        : PdfDocumentHelper.ReadPdfContent(files[0]);

                    rtb.Text = content;

                    if (rtb.Tag is Action<string> callback)
                        callback.Invoke(files[0]);
                }
                catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
            }
        }

    }
}