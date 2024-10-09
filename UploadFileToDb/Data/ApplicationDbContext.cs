using Microsoft.EntityFrameworkCore;
using UploadFileToDb.Models;
namespace UploadFileToDb.Data
{
    public class ApplicationDbContext : DbContext
     
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) 
        {  

        }
        public DbSet<FileCreation> FileCreations { get; set; }
    }
}
