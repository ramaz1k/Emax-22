using Domain.Models;

namespace Domain.Interfaces;

public interface IProductRepository
{
    Task<bool> CreateProductAsync(Product product);
    Task<List<Product>> GetAllProductsAsync();
    Task<bool> UpdateProductAsync(Product product);
    Task <bool>DeleteProductAsync(int id);
    Task <Product?> GetProductByIdAsync(int id);
    
}
