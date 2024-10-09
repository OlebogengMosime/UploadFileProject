using UploadFileToDb.Models;

namespace UploadFileToDb.FileUploadViewModel
{
    public class FileUploadViewModel : FileCreation
    {
        public byte[] data { get; set; }

        public List<FileCreation> SystemFiles { get; set; }


    }
}
