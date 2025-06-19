using Authentication_Demo.DTOs;
using Authentication_Demo.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Authentication_Demo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepo _repo;

        public ProductsController(IProductRepo repo)
        {
            _repo = repo;
        }

        [HttpGet("all")]
        public IActionResult GetAllProducts()
        {
            try
            {
                var products = _repo.GetAllProducts();
                return products == null || !products.Any() ? NotFound("No products found.") : Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error in GetAllProducts: {ex.Message}");
            }
        }

        [HttpGet("id/{id:int}")]
        public IActionResult GetProductById(int id)
        {
            try
            {
                var product = _repo.GetProductById(id);
                return product == null ? NotFound($"Product with ID {id} not found.") : Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error in GetProductById: {ex.Message}");
            }
        }

        [HttpGet("search/name")]
        public IActionResult GetProductByName([FromQuery] string name)
        {
            try
            {
                var products = _repo.GetProductByName(name);
                return products == null || !products.Any() ? NotFound($"No products found with name '{name}'.") : Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error in GetProductByName: {ex.Message}");
            }
        }

        [HttpGet("search/price")]
        public IActionResult GetProductsByPrice([FromQuery] int price)
        {
            try
            {
                var products = _repo.SearchProductsByPrice(price);
                return products == null || !products.Any() ? NotFound($"No products found with price >= {price}.") : Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error in GetProductsByPrice: {ex.Message}");
            }
        }

        [HttpPost("create")]
        public IActionResult AddProduct([FromBody] ProductCreationDTO productDTO)
        {
            try
            {
                if (productDTO == null) return BadRequest("Invalid product data.");
                var result = _repo.AddProduct(productDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error in AddProduct: {ex.Message}");
            }
        }

        [HttpPut("update/{id:int}")]
        public IActionResult UpdateProduct(int id, [FromBody] ProductUpdateDTO product)
        {
            try
            {
                if (product == null) return BadRequest("Product data is invalid.");
                var result = _repo.UpdateProduct(id, product);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error in UpdateProduct: {ex.Message}");
            }
        }

        [HttpDelete("delete/{id:int}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                var result = _repo.DeleteProduct(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error in DeleteProduct: {ex.Message}");
            }
        }

        [HttpGet("category/{category}")]
        public IActionResult GetProductsByCategory(string category)
        {
            try
            {
                var products = _repo.GetProductsByCategory(category);
                return products == null || !products.Any()
                    ? NotFound($"No products found in category '{category}'.")
                    : Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error in GetProductsByCategory: {ex.Message}");
            }
        }

        [HttpGet("lowstock/{threshold:int}")]
        public IActionResult GetLowStockProducts(int threshold)
        {
            try
            {
                var products = _repo.GetLowStockProducts(threshold);
                return products == null || !products.Any()
                    ? NotFound($"No low stock products found below quantity {threshold}.")
                    : Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error in GetLowStockProducts: {ex.Message}");
            }
        }
    }
}
