using System.Diagnostics;
using _1_Introduction.Models;
using Microsoft.AspNetCore.Mvc;

namespace _1_Introduction.Controllers
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

        //public string index1(int id)
        //{
        //    return $"you entered : {id}";
        //}

        [Route("home/index1/{studentid}")]
        public string index1(int studentid)
        {
            return $"you entered : {studentid} id";
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
