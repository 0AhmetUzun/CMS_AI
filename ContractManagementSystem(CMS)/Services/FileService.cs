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
    }
}
