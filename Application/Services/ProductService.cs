using System.Net;
using Application.DTO.CategoryDTO;
using Application.DTO.ProductDTO;
using Application.Interfaces;
using Domain.ApieResponse;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.Extensions.Logging;

namespace Application.Services;

public class ProductService(IProductRepository productRepository, ILogger<ProductService> logger) : IProductService
{
    private readonly IProductRepository repository = productRepository;
    private readonly ILogger<ProductService> _logger = logger;


    public async Task<Response<bool>> CreateProductAsync(CreateProductDto product)
    {

        try
        {
            var p = new Product
            {
                CategoryId = product.CategoryId,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Quantity = product.Quantity
            };

            var res = await repository.CreateProductAsync(p);
            return res
                ? new Response<bool>(HttpStatusCode.OK, "Successfully added", res)
                : new Response<bool>(HttpStatusCode.OK, "Not added", res);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while creating product");
            return new Response<bool>(HttpStatusCode.InternalServerError, "Internal server error");
        }



    }

    public async Task<Response<bool>> DeleteProductAsync(int id)
    {
        try
        {
            var res = await repository.DeleteProductAsync(id);
            return res
                ? new Response<bool>(HttpStatusCode.OK, "Deleted", res)
                : new Response<bool>(HttpStatusCode.OK, "Something went wrong", res);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while deleting product");
            return new Response<bool>(HttpStatusCode.InternalServerError, "Internal server error");
        }
    }



    public async Task<Response<IEnumerable<ProductDTO>>> GetAllProductAsync()
    {
        var res = await repository.GetAllProductsAsync();
        var data = res.Select(x => new ProductDTO
        {
            Id = x.Id,
            CategoryId = x.CategoryId,
            Name = x.Name,
            Description = x.Description,
            Price = x.Price,
            Quantity = x.Quantity,
            CreatedAt = x.CreatedAt,

        }).ToList();

        return new Response<IEnumerable<ProductDTO>>(HttpStatusCode.OK, "List of Products", data);
    }

    public async Task<Response<ProductDTO>> GetProductbyIdAsync(int id)
    {

        var res = await repository.GetProductByIdAsync(id);
        var data = new ProductDTO
        {
            Id = res.Id,
            CategoryId = res.CategoryId,
            Name = res.Name,
            Description = res.Description,
            Price = res.Price,
            Quantity = res.Quantity,
            CreatedAt = res.CreatedAt,
        };

        return new Response<ProductDTO>(HttpStatusCode.OK, "Product by id", data);
    }

    public async Task<Response<bool>> UpdateProductAsync(UpdateProductDto product)
    {
          try
        {
            var p = new Product
            {
                CategoryId = product.CategoryId,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Quantity = product.Quantity
            };

            var res = await repository.UpdateProductAsync(p);
            return res
                ? new Response<bool>(HttpStatusCode.OK, "Updated", res)
                : new Response<bool>(HttpStatusCode.OK, "Something went wrong", res);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while updating product");
            return new Response<bool>(HttpStatusCode.InternalServerError, "Internal server error");
        }


    }

}
