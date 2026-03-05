using Microsoft.AspNetCore.Mvc;

namespace DataTransfer_Technique.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index1(int Id)
        {
            ViewBag.Id = Id;
            return View();
        }
    }
}
