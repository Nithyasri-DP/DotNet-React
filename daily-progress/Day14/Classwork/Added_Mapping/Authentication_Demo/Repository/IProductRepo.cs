using Authentication_Demo.DTOs;
using Authentication_Demo.Models;

namespace Authentication_Demo.Repository
{
    public interface IProductRepo
    {
        List<ProductDTO> GetAllProducts();
        ProductDTO GetProductById(int id);
        List<ProductDTO> GetProductByName(string name);
        List<ProductDTO> SearchProductsByPrice(int price);
        string AddProduct(ProductCreationDTO product);
        string UpdateProduct(int id, ProductUpdateDTO product);
        string DeleteProduct(int id);

        List<Product> GetProductsByCategory(string category);
        List<Product> GetLowStockProducts(int threshold);
    }
}

