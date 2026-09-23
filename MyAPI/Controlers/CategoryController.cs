using Application.DTO.CategoryDTO;
using Application.Interfaces;
using Domain.ApieResponse;
using Microsoft.AspNetCore.Mvc;

namespace MyAPI.Controlers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController(ICategoryService categoryService) : ControllerBase
{
    private ICategoryService service = categoryService;

    [HttpGet]
    public async Task<Response<IEnumerable<CategoryDto>>> GetAllCategoriesAsync()
    {
        return await service.GetAllCategoriesAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<Response<CategoryDto>> GetCategoryByIdAsync(int id)
    {
        return await service.GetCategoryByIdAsync(id);
    }

    [HttpPost]
    public async Task<Response<bool>> CreateCategoryAsync([FromQuery] CreateCategoryDto category)
    {
        return await service.CreateCategoryAsync(category);
    }

    [HttpPut]
    public async Task<Response<bool>> UpdateCategoryAsync([FromQuery] UpdateCategoryDto category)
    {
        return await service.UpdateCategoryAsync(category);
    }

    [HttpDelete("{id:int}")]
    public async Task<Response<bool>> DeleteCategoryAsync(int id)
    {
        return await service.DeleteCategoryAsync(id);
    }

}
