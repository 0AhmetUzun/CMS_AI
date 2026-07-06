using System;
using System.IO;
using System.Text;
using NPOI.XWPF.UserModel;

namespace ContractManagementSystem_CMS_.Services
{
    public class FileService
    {
        public string ReadWordDoc(string filePath)
        {
            return WordDocumentHelper.ReadFullContent(filePath);
        }

        public string ReadPdf(string filePath)
        {
            return PdfDocumentHelper.ReadPdfContent(filePath);
        }

        public string ReadDocument(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLower();
            return extension switch
            {
                ".docx" => ReadWordDoc(filePath),
                ".pdf" => ReadPdf(filePath),
                _ => throw new NotSupportedException("Desteklenmeyen dosya formatı: " + extension)
            };
        }

        public bool IsSupportedFormat(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLower();
            return extension == ".docx" || extension == ".pdf";
        }
    }
}
