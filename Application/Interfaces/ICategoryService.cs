using System.Net;
using Application.DTO.CategoryDTO;
using Domain.ApieResponse;
using Domain.Models;

namespace Application.Interfaces;

public interface ICategoryService
{
    Task<Response<IEnumerable<CategoryDto>>> GetAllCategoriesAsync();
    Task<Response<CategoryDto>> GetCategoryByIdAsync(int id);
    Task<Response<bool>> CreateCategoryAsync(CreateCategoryDto category);
    Task<Response<bool>> UpdateCategoryAsync(UpdateCategoryDto category);
    Task<Response<bool>> DeleteCategoryAsync(int id);
}

