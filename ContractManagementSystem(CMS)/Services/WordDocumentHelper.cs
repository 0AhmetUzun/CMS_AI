using System;
using System.IO;
using System.Text;
using NPOI.XWPF.UserModel;

namespace ContractManagementSystem_CMS_.Services
{
    public static class WordDocumentHelper
    {
        public static string ReadParagraphsOnly(string filePath)
        {
            if (string.IsNullOrEmpty(filePath)) return string.Empty;

            StringBuilder sb = new StringBuilder();
            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    XWPFDocument doc = new XWPFDocument(fs);
                    foreach (var para in doc.Paragraphs)
                    {
                        sb.AppendLine(para.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Dosya okunurken bir hata oluştu: " + ex.Message);
            }

            return sb.ToString();
        }

        public static string ReadFullContent(string filePath)
        {
            if (string.IsNullOrEmpty(filePath)) return string.Empty;

            StringBuilder sb = new StringBuilder();
            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    XWPFDocument doc = new XWPFDocument(fs);

                    foreach (var para in doc.Paragraphs)
                    {
                        sb.AppendLine(para.ParagraphText);
                    }

                    foreach (var table in doc.Tables)
                    {
                        foreach (var row in table.Rows)
                        {
                            foreach (var cell in row.GetTableCells())
                            {
                                sb.Append(cell.GetText() + "\t");
                            }
                            sb.AppendLine();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Dosya okunurken bir hata oluştu: " + ex.Message);
            }

            return sb.ToString();
        }

        public static void WriteDocument(string content, Dictionary<string, string> fields, string outputPath)
        {
            if (string.IsNullOrEmpty(outputPath)) throw new Exception("Çıktı dosya yolu boş olamaz.");

            string? directory = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            try
            {
                using (XWPFDocument doc = new XWPFDocument())
                {
                    string[] lines = content.Replace("\r\n", "\n").Split('\n');
                    foreach (var rawLine in lines)
                    {
                        string line = ReplacePlaceholders(rawLine, fields);
                        var para = doc.CreateParagraph();
                        para.Alignment = LineIsHeading(rawLine) ? ParagraphAlignment.CENTER : ParagraphAlignment.LEFT;
                        var run = para.CreateRun();
                        run.SetText(line);
                        run.FontSize = LineIsHeading(rawLine) ? 14 : 11;
                        run.IsBold = LineIsHeading(rawLine);
                    }

                    using (var fs = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                    {
                        doc.Write(fs);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Word belgesi oluşturulurken hata: " + ex.Message);
            }
        }

        private static string ReplacePlaceholders(string text, Dictionary<string, string> fields)
        {
            if (string.IsNullOrEmpty(text)) return text;

            foreach (var kvp in fields)
            {
                string placeholder = "[[" + kvp.Key + "]]";
                if (text.Contains(placeholder))
                {
                    text = text.Replace(placeholder, kvp.Value ?? "");
                }
            }

            // Doldurulmamış placeholder'ları temizle
            int idx;
            while ((idx = text.IndexOf("[[")) >= 0)
            {
                int end = text.IndexOf("]]", idx);
                if (end < 0) break;
                text = text.Remove(idx, end - idx + 2);
            }

            return text;
        }

        private static bool LineIsHeading(string line)
        {
            if (string.IsNullOrWhiteSpace(line)) return false;
            string trimmed = line.Trim();
            return trimmed.EndsWith("SÖZLEŞMESİ") || trimmed.EndsWith("SOZLESMESI") ||
                   (trimmed.StartsWith("Madde") && trimmed.Contains("-"));
        }
    }
}
