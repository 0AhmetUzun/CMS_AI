using System;
using System.IO;
using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace ContractManagementSystem_CMS_.Services
{
    public static class PdfDocumentHelper
    {
        public static string ReadPdfContent(string filePath)
        {
            if (string.IsNullOrEmpty(filePath)) return string.Empty;
            if (!File.Exists(filePath)) throw new FileNotFoundException("PDF dosyası bulunamadı: " + filePath);

            StringBuilder sb = new StringBuilder();
            try
            {
                using (PdfReader reader = new PdfReader(filePath))
                {
                    for (int i = 1; i <= reader.NumberOfPages; i++)
                    {
                        ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                        string pageText = PdfTextExtractor.GetTextFromPage(reader, i, strategy);
                        sb.AppendLine(pageText);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("PDF dosyası okunurken bir hata oluştu: " + ex.Message);
            }

            return sb.ToString();
        }
    }
}
