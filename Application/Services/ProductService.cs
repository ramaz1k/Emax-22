using Application.Interfaces;
using Domain.ApieResponse;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class ProductService : IProductService
{
  
    public Task<Response<Product>> CreateProductAsync(Product product)
    {

    }  
    

    public Task<Response<string>> DeleteProductAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Category>> GetAllProductAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Response<Product>> GetProductbyIdAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Response<string>> UpdateProductAsync(Product product)
    {
        throw new NotImplementedException();
    }
}