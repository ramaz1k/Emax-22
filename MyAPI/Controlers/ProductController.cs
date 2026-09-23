using Application.DTO.CategoryDTO;
using Application.DTO.ProductDTO;
using Application.Interfaces;
using Domain.ApieResponse;
using Microsoft.AspNetCore.Mvc;

namespace MyAPI.Controlers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IProductService productService) : ControllerBase
{
    private IProductService service =productService;


    [HttpGet]
    public async Task<Response<IEnumerable<ProductDTO>>> GetAllProductsAsync()
    {
        return await service.GetAllProductAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<Response<ProductDTO>> GetProductByIdAsync(int id)
    {
        return await service.GetProductbyIdAsync(id);
    }

    [HttpPost]
    public async Task<Response<bool>> CreateProductAsync([FromQuery] CreateProductDto product)
    {
        return await service.CreateProductAsync(product);
    }

    [HttpPut]
    public async Task<Response<bool>> UpdateProductAsync([FromQuery] UpdateProductDto product)
    {
        return await service.UpdateProductAsync(product);
    }

    [HttpDelete("{id:int}")]
    public async Task<Response<bool>> DeleteProductAsync(int id)
    {
        return await service.DeleteProductAsync(id);
    }

}
