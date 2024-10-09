using System.ComponentModel.DataAnnotations;

namespace UploadFileToDb.Models
{
    public class FileCreation
    {
        public int Id { get; set; }

        [Display(Name ="File Name")]
        public string FileName { get; set; }

        [Display(Name = "File Type")]
        public string FileType { get; set; }

        [Display(Name = "File Extension")]
        public string Extention { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set;}
    }
}
