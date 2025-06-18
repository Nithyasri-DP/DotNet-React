using Authentication_Demo.Contexts;
using Authentication_Demo.Models;
using Authentication_Demo.Repository;
using Authentication_Demo.Contexts;
using Authentication_Demo.Models;

namespace Authentication_Demo.Repository
{
    public class ProductRepo : IProductRepo
    {
        private readonly ProductContext _context;

        public ProductRepo(ProductContext context)
        {
            _context = context;
        }

        public string AddProduct(Product product)
        {
            try
            {
                if (product != null)
                {
                    _context.Products.Add(product);
                    _context.SaveChanges();
                    return "Product added successfully";
                }
                else
                {
                    return "Enter product details properly";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //public string DeleteProduct(int id)
        //{
        //    try
        //    {
        //        var product = GetProductById(id);
        //        if (product != null)
        //        {
        //            product.IsActive = false;
        //            _context.SaveChanges();
        //            return "Product deleted successfully";
        //        }
        //        else
        //        {
        //            return $"Product with Id {id} not found";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        public string DeleteProduct(int id)
        {
            try
            {
                var product = GetProductById(id);
                if (product == null)
                {
                    return $"Product with Id {id} not found";
                }

                if (!product.IsActive)
                {
                    // Already soft deleted — now hard delete
                    _context.Products.Remove(product);
                    _context.SaveChanges();
                    return "Product permanently deleted";
                }
                else
                {
                    // First delete — perform soft delete
                    product.IsActive = false;
                    _context.SaveChanges();
                    return "Product soft deleted (marked as inactive)";
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in DeleteProduct: {ex.Message}");
            }
        }


        //public List<Product> GetAllProducts()
        //{
        //    try
        //    {
        //        var products = _context.Products.ToList();
        //        return products.Count > 0 ? products : null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"Exception in GetAllProducts: {ex.Message}");
        //    }
        //}

        public List<Product> GetAllProducts()
        {
            try
            {
                var products = _context.Products
                    .Where(p => p.IsActive == true) 
                    .ToList();

                return products;
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception in GetAllProducts: {ex.Message}");
            }
        }

        public Product GetProductById(int id)
        {
            try
            {
                var product = _context.Products.FirstOrDefault(x => x.Id == id);
                return product ?? null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception in GetProductById: {ex.Message}");
            }
        }

        public List<Product> GetProductByName(string name)
        {
            try
            {
                if (!string.IsNullOrEmpty(name))
                {
                    var products = _context.Products
                        .Where(p => !string.IsNullOrEmpty(p.Name) &&
                                    p.Name.ToLower().Contains(name.ToLower()))
                        .ToList();
                    return products;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception in GetProductByName: {ex.Message}");
            }
        }

        public List<Product> SearchProductsByPrice(int price)
        {
            try
            {
                var products = _context.Products
                    .Where(p => p.SellingPrice >= price)
                    .ToList();
                return products.Count > 0 ? products : null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception in SearchProductsByPrice: {ex.Message}");
            }
        }

        public string UpdateProduct(int id, Product product)
        {
            try
            {
                var existingProduct = GetProductById(id);
                if (existingProduct == null)
                {
                    return $"Product with Id {id} not found";
                }

                existingProduct.Name = product.Name;
                existingProduct.ManufacturedDate = DateTime.Now;
                existingProduct.ManufacturingCost = product.ManufacturingCost;
                existingProduct.SellingPrice = product.SellingPrice;
                existingProduct.IsActive = product.IsActive;

                _context.SaveChanges();

                return $"Product with Id {id} updated successfully";
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception in UpdateProduct: {ex.Message}");
            }
        }
    }
}
