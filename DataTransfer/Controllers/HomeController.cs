using DataTransfer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DataTransfer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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

        public ViewResult Index1()
        {
            ViewData["name"] = "pankaj more";

            ViewBag.email = "pankaj@more";

            return View();
        }

        public ViewResult Index2()
        {
            return View();
        }

        public ViewResult Index3()
        {
            string fullname = "pankaj more";

            return View(fullname);
        }
    }
}
