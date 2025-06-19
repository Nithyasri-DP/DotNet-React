using WebAPI_MVC.DTOs;
using WebAPI_MVC.Models;

namespace WebAPI_MVC.Services
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;
        public ProductService(HttpClient client)
        {
            _httpClient = client;
        }

        // Get all products
        public async Task<List<ProductDTO>> GetProductsAsync() =>
              await _httpClient.GetFromJsonAsync<List<ProductDTO>>("api/products/all");

        // Get a product by its ID
        public async Task<ProductDTO> GetProductById(int id) =>
            await _httpClient.GetFromJsonAsync<ProductDTO>($"api/products/id/{id}");

        // Search products by name
        public async Task<List<ProductDTO>> SearchProductByName(string name) =>
            await _httpClient.GetFromJsonAsync<List<ProductDTO>>($"api/products/search/name?name={name}");

        // Get products by price
        public async Task<List<ProductDTO>> GetProductsByPrice(int price) =>
            await _httpClient.GetFromJsonAsync<List<ProductDTO>>($"api/products/search/price?price={price}");

        // Get products by category
        public async Task<List<Product>> GetProductsByCategory(string category) =>
            await _httpClient.GetFromJsonAsync<List<Product>>($"api/products/category/{category}");

        // Get low stock products based on a threshold
        public async Task<List<Product>> GetLowStockProducts(int threshold) =>
            await _httpClient.GetFromJsonAsync<List<Product>>($"api/products/lowstock/{threshold}");

        // Create a new product
        public async Task<string> CreateProduct(ProductCreationDTO productDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("api/products/create", productDTO);
            return await response.Content.ReadAsStringAsync();
        }

        // Update an existing product
        public async Task<string> UpdateProductAsync(int id, ProductUpdateDTO productDTO)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/products/update/{id}", productDTO);
            return await response.Content.ReadAsStringAsync();
        }

        // Delete a product
        public async Task<string> DeleteProduct(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/products/delete/{id}");
            return await response.Content.ReadAsStringAsync();
        }
    }
}
