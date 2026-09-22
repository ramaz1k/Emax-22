using System.Net;
using Domain.ApieResponse;
using Domain.Models;

namespace Application.Interfaces;

public interface ICategoryService
{
    Task<Response<IEnumerable<Category>>> GetAllCategoriesAsync();
    Task<Response<Category>> GetCategoryByIdAsync(int id);
    Task<Response<Category>> CreateCategoryAsync(Category category);
    Task<Response<string>> UpdateCategoryAsync(Category category);
    Task<Response<string>> DeleteCategoryAsync(int id);
}

