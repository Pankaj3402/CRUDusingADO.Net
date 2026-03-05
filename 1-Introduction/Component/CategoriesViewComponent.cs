using Microsoft.AspNetCore.Mvc;

namespace _1_Introduction.Component
{
    public class CategoriesViewComponent : ViewComponent
    {

        //Invoke orInvokeAsync method is used to execute the logic of the view component and return a view or a result.

        public IViewComponentResult Invoke()
        {
            // In a real application, you would typically retrieve data from a database or service here.
            // For demonstration purposes, we'll use a hardcoded list of categories.
            var categories = new List<string>
            {
                "Electronics",
                "Books",
                "Clothing",
                "Home & Kitchen",
                "Sports & Outdoors"
            };
            // Pass the categories to the view
            return View(categories);
        }
    }
}
