﻿using Authentication_Demo.Models;
using Authentication_Demo.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Authentication_Demo.Controllers
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

        //[HttpGet("AllProducts")]
        //public async Task<IActionResult> Get()
        //{
        //    try
        //    {
        //        var products = _repo.GetAllProducts();
        //        if (products == null)
        //        {
        //            return NotFound("No products found.");
        //        }
        //        return Ok(products);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"Exception in GetAllProducts: {ex.Message}");
        //    }
        //}

        [HttpGet("AllProducts")]
        public async Task<ActionResult<List<Product>>> Get()
        {
            try
            {
                var result = _repo.GetAllProducts();
                if (result == null || result.Count == 0)
                    return NotFound("No active products found");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error fetching products: " + ex.Message); 
            }
        }


        [HttpGet("productbyid/{id:int}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                var product = _repo.GetProductById(id);
                if (product == null)
                {
                    return NotFound($"Product with ID {id} not found.");
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception in GetProductById: {ex.Message}");
            }
        }

        [HttpGet("searchbyname")]
        public async Task<IActionResult> GetProductsByName(string name)
        {
            try
            {
                var products = _repo.GetProductByName(name);
                if (products == null || products.Count == 0)
                {
                    return NotFound($"No products found with name containing '{name}'.");
                }
                return Ok(products);
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception in GetProductsByName: {ex.Message}");
            }
        }

        [HttpGet("searchbyprice")]
        public async Task<IActionResult> GetProductsByPrice(int price)
        {
            try
            {
                var products = _repo.SearchProductsByPrice(price);
                if (products == null || products.Count == 0)
                {
                    return NotFound($"No products found with price >= {price}.");
                }
                return Ok(products);
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception in GetProductsByPrice: {ex.Message}");
            }
        }

        [HttpPost("addnewproduct")]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            try
            {
                var response = _repo.AddProduct(product);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception in CreateProduct: {ex.Message}");
            }
        }

        [HttpPut("updateproduct/{id:int}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            try
            {
                var response = _repo.UpdateProduct(id, product);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception in UpdateProduct: {ex.Message}");
            }
        }

        [HttpDelete("deleteproduct/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var response = _repo.DeleteProduct(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception in DeleteProduct: {ex.Message}");
            }
        }
    }
}
