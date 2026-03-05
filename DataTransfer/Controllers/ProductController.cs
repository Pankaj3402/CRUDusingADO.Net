using DataTransfer_Technique.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;

namespace DataTransfer_Technique.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMemoryCache _cache;
        private const string CacheKey = "Products";

        public ProductController(IMemoryCache cache)
        {
            _cache = cache;
        }

        // 🔹 READ - List Products
        [HttpGet]
        public IActionResult Index()
        {
            var products = GetProducts();
            return View(products);
        }

        // 🔹 CREATE - GET
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // 🔹 CREATE - POST
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
                return View(product);

            var products = GetProducts();

            product.Id = products.Any() ? products.Max(p => p.Id) + 1 : 1;
            products.Add(product);

            _cache.Set(CacheKey, products);
            return RedirectToAction(nameof(Index));
        }

        // 🔹 EDIT - GET
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var products = GetProducts();
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound();

            return View(product);
        }

        // 🔹 EDIT - POST
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (!ModelState.IsValid)
                return View(product);

            var products = GetProducts();
            var existing = products.FirstOrDefault(p => p.Id == product.Id);

            if (existing == null)
                return NotFound();

            existing.Name = product.Name;
            existing.Price = product.Price;

            _cache.Set(CacheKey, products);
            return RedirectToAction(nameof(Index));
        }

        // 🔹 DELETE - GET
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var products = GetProducts();
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound();

            return View(product);
        }

        // 🔹 DELETE - POST
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var products = GetProducts();
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product != null)
            {
                products.Remove(product);
                _cache.Set(CacheKey, products);
            }

            return RedirectToAction(nameof(Index));
        }

        // 🔹 DETAILS
        [HttpGet]
        public IActionResult Details(int id)
        {
            var products = GetProducts();
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound();

            return View(product);
        }

        // 🔹 Helper Method (Seed Data ONCE)
        private List<Product> GetProducts()
        {
            if (!_cache.TryGetValue(CacheKey, out List<Product> products))
            {
                products = new List<Product>()
                {
                    new Product { Id = 1, Name = "Laptop", Price = 75000m },
                    new Product { Id = 2, Name = "Mobile", Price = 25000m },
                    new Product { Id = 3, Name = "Tablet", Price = 18000m }
                };

                _cache.Set(CacheKey, products);
            }

            return products;
        }
    }
}