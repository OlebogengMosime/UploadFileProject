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

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index(FileUploadViewModel.FileUploadViewModel vm)
        {

            vm.SystemFiles = new List<FileCreation>();

            return View(vm);
        }

        [HttpPost]
        public IActionResult UploadFile(FileUploadViewModel.FileUploadViewModel vm, IFormFile file)
        {

            vm.SystemFiles = new List<FileCreation>();

            return View(vm);
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
