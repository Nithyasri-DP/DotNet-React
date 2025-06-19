using Authentication_Demo.Contexts;
using Authentication_Demo.DTOs;
using Authentication_Demo.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Authentication_Demo.Repository
{
    public class ProductRepo : IProductRepo
    {
        private readonly ProductContext _context;
        private readonly IMapper _mapper;

        public ProductRepo(ProductContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public string AddProduct(ProductCreationDTO productDTO)
        {
            try
            {
                if (productDTO != null)
                {
                    var product = _mapper.Map<Product>(productDTO);
                    product.CreatedDate = DateTime.Now;
                    product.IsActive = true;

                    _context.Products.Add(product);
                    _context.SaveChanges();
                    return "Product added successfully";
                }

                return "Enter product details properly";
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in AddProduct: {ex.Message}");
            }
        }

        public string DeleteProduct(int id)
        {
            try
            {
                var product = _context.Products.FirstOrDefault(p => p.Id == id);

                if (product == null)
                    return $"Product with Id {id} not found";

                if (!product.IsActive)
                {
                    _context.Products.Remove(product);
                    _context.SaveChanges();
                    return "Product permanently deleted";
                }
                else
                {
                    product.IsActive = false;
                    product.UpdatedDate = DateTime.UtcNow;
                    _context.SaveChanges();
                    return "Product soft deleted (marked as inactive)";
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in DeleteProduct: {ex.Message}");
            }
        }

        public List<ProductDTO> GetAllProducts()
        {
            try
            {
                var products = _context.Products
                    .Where(p => p.IsActive)
                    .ToList();

                return _mapper.Map<List<ProductDTO>>(products);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in GetAllProducts: {ex.Message}");
            }
        }

        public ProductDTO GetProductById(int id)
        {
            try
            {
                var product = _context.Products.FirstOrDefault(p => p.Id == id && p.IsActive);
                return product != null ? _mapper.Map<ProductDTO>(product) : null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception in GetProductById: {ex.Message}");
            }
        }

        public List<ProductDTO> GetProductByName(string name)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    var products = _context.Products
                        .Where(p => p.Name.ToLower().Contains(name.ToLower()) && p.IsActive)
                        .ToList();

                    return _mapper.Map<List<ProductDTO>>(products);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception in GetProductByName: {ex.Message}");
            }
        }

        public List<ProductDTO> SearchProductsByPrice(int price)
        {
            try
            {
                var products = _context.Products
                    .Where(p => p.SellingPrice >= price && p.IsActive)
                    .ToList();

                return _mapper.Map<List<ProductDTO>>(products);
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception in SearchProductsByPrice: {ex.Message}");
            }
        }

        public string UpdateProduct(int id, ProductUpdateDTO productDTO)
        {
            try
            {
                var existingProduct = _context.Products.FirstOrDefault(p => p.Id == id);

                if (existingProduct == null)
                    return $"Product with Id {id} not found";

                // Map updates
                _mapper.Map(productDTO, existingProduct);
                existingProduct.UpdatedDate = DateTime.UtcNow;

                _context.SaveChanges();
                return $"Product with Id {id} updated successfully";
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in UpdateProduct: {ex.Message}");
            }
        }

        public List<Product> GetProductsByCategory(string category)
        {
            return _context.Products
                .Where(p => p.Category.ToLower() == category.ToLower())
                .ToList();
        }

        public List<Product> GetLowStockProducts(int threshold)
        {
            return _context.Products
                .Where(p => p.Quantity < threshold)
                .ToList();
        }

    }
}
