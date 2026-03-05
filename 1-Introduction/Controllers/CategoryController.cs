using _1_Introduction.Models;
using Microsoft.AspNetCore.Mvc;

namespace _1_Introduction.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            List<Category>categories=new List<Category>()
            {
                new Category(){Id=1,Name="Category 1",Owner="John"},
                new Category(){Id=2,Name="Category 2",Owner="Jane"},
                new Category(){Id=3,Name="Category 3",Owner="Bob"},
            };

            return View(categories); // Passing the list of categories to the view
        }

        public ViewResult Details()
        {
            Category category = new Category() { Id = 1,Name="category 1", Owner="owner 1" };
            return View(category); // Returning the Details view
        }
    }
}
