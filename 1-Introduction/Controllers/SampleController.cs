using Microsoft.AspNetCore.Mvc;

namespace _1_Introduction.Controllers
{
    public class SampleController : Controller
    {
        public string index1()
        {
            return "Hello World!";
        }

        public EmptyResult Index2()
        {
            return new EmptyResult(); // This method returns an empty result, which means it will not return any content to the client.
        }

        public ContentResult Index3()
        {
            return Content("sample index 3 called");
           
        }

        public ContentResult Index4()
        {
            return Content("<h1>sample index 4 called</h1>","text/html");

        }

        public ViewResult Index5()
        {
            //return View();
            return View("Views/Sample/Index55.cshtml");
        }

        public ViewResult Index6()
        {
            return View();
        }

        public ViewResult Index7()
        {
            return View();
        }

        public ViewResult Index8()
        {
            return View();
        }

        public ViewResult Index9()
        {
            return View();
        }
    }
}
