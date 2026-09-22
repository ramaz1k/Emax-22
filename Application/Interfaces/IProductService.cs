using Domain.ApieResponse;
using Domain.Models;

namespace Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<Category>>GetAllProductAsync();
    Task<Response<Product>>GetProductbyIdAsync();
    Task<Response<Product>>CreateProductAsync(Product product);
    Task<Response<string>>UpdateProductAsync(Product product);
    Task<Response<string>>DeleteProductAsync(int id);    
    }
