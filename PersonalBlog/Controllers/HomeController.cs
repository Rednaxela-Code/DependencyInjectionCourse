using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Interface;
using PersonalBlog.Models;
using PersonalBlog.Services;
using System.Diagnostics;
using System.Linq.Expressions;

namespace PersonalBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDataService _dataService;

        public HomeController(ILogger<HomeController> logger, IDataService dataService)
        {
            _logger = logger;
            _dataService = dataService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("Post")]
        [HttpGet]
        [ServiceFilter(typeof(ProtectorAttribute))]
        public async Task<IActionResult> CreatePost(Post model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Validation", "Please provide all values");
            }
            return View(model);
        }

        [HttpPost]
        [ServiceFilter(typeof(ProtectorAttribute))]
        public async Task<IActionResult> Post(Post model)
        {
            await _dataService.Create(model);
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
