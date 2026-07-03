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
    }
}
