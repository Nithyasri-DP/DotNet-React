using Authentication_Demo.Models;

namespace Authentication_Demo.Repository
{
    public interface IProductRepo
    {
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        List<Product> GetProductByName(string name);
        List<Product> SearchProductsByPrice(int price);
        string AddProduct(Product product);
        string UpdateProduct(int id, Product product);
        string DeleteProduct(int id);
    }
}
