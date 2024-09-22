using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GoSell.Affiliate.Tracking.ViewModels
{
    public class FileDataViewModel
    {
        public MemoryStream File { get; set; }
        public string FileName { get; set; }

        // Constructor
        public FileDataViewModel(MemoryStream file, string fileName)
        {
            File = file;
            FileName = fileName;
        }
    }
    public class ResultImportDataViewModel
    {
        public byte[] File { get; set; }
        public string FileName { get; set; }
        public int TotalRowSuccess { get; set; }
        public int TotalRowFail { get; set; }

        // Constructor
        public ResultImportDataViewModel(byte[] file, string fileName, int totalRowSuccess, int totalRowFail)
        {
            File = file;
            FileName = fileName;
            TotalRowSuccess = totalRowSuccess;
            TotalRowFail = totalRowFail;
        }
    }
}
