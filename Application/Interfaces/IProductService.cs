using Application.DTO.CategoryDTO;
using Application.DTO.ProductDTO;
using Domain.ApieResponse;
using Domain.Models;

namespace Application.Interfaces;

public interface IProductService
{
    Task<Response<IEnumerable<ProductDTO>>>GetAllProductAsync();
    Task<Response<ProductDTO>>GetProductbyIdAsync(int id);
    Task<Response<bool>>CreateProductAsync(CreateProductDto product);
    Task<Response<bool>>UpdateProductAsync(UpdateProductDto product);
    Task<Response<bool>>DeleteProductAsync(int id);    
    }
