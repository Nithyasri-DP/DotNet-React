using Microsoft.AspNetCore.Mvc;
using WebAPI_MVC.Services;
using WebAPI_MVC.Models;

namespace WebAPI_MVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductService _service;

        public ProductsController(ProductService service)
        {
            _service = service;
        }

        // GET: /Products
        public async Task<IActionResult> Index(string searchItem)
        {
            var products = string.IsNullOrEmpty(searchItem)
                ? await _service.GetProductsAsync()
                : await _service.SearchProductByName(searchItem);

            ViewBag.SearchItem = searchItem;
            return View(products);
        }

        // GET: /Products/Create
        public IActionResult Create() => View();

        // POST: /Products/Create
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            await _service.CreateProduct(product);
            return RedirectToAction("Index");
        }

        // GET: /Products/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _service.GetProductById(id);
            return View(product);
        }

        // POST: /Products/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            await _service.UpdateProductAsync(product.Id, product);
            return RedirectToAction("Index");
        }

        // GET: /Products/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var product = await _service.GetProductById(id);
            return View(product);
        }

        // GET: /Products/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _service.GetProductById(id);
            return View(product);
        }

        // POST: /Products/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}
