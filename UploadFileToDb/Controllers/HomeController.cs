using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UploadFileToDb.Data;
using UploadFileToDb.FileUploadViewModel;
using UploadFileToDb.Models;

namespace UploadFileToDb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration,ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index(FileUploadViewModel.FileUploadViewModel vm)
        {

            vm.SystemFiles = new List<FileCreation>();

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(FileUploadViewModel.FileUploadViewModel vm, IFormFile file)
        {
            var filename = $"{file.FileName}_{DateTime.Now.ToString("yyyymmddhhmmss")}";
            var path = $"{_configuration.GetSection("FileManagement:SystemFileUploads").Value}";
            var filepath = Path.Combine(path, filename);
            var fileextension = Path.GetExtension(filename);

            var stream = new FileStream(filepath, FileMode.Create);
            await file.CopyToAsync(stream);


            var uploadfile = new FileCreation
            { 
                FileName = filename,
                CreatedOn = DateTime.Now,
                FileType = file.ContentType,
                Description = vm.Description,
                Extention = fileextension,
            };


            await _context.AddAsync(uploadfile);
            await _context.SaveChangesAsync();

            //vm.SystemFiles = new List<FileCreation>();

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
