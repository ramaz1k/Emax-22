using Application.DTO.CategoryDTO;
using Application.Interfaces;
using Domain.ApieResponse;
using Domain.Interfaces;
using Dapper;
using Microsoft.Extensions.Logging;
using System.Net;
using Domain.Models;
namespace Application.Services;

public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
{
    private readonly ICategoryRepository categoryRepository1 = categoryRepository;
    private readonly ILogger<CategoryService> _logger;


    public async Task<Response<bool>> CreateCategoryAsync(CreateCategoryDto category)
    {
          try
        {
            var c = new Category()
            {
                Name = category.Name,
                Description = category.Description!
            };
            var res = await categoryRepository1.CreateCategoryAsync(c);
            return res == true
                ? new Response<bool>(HttpStatusCode.OK, "successfully added", res)
                : new Response<bool>(HttpStatusCode.OK, "not added", res);
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "Error while creating category");
             return new Response<bool>(HttpStatusCode.InternalServerError, "Internal server error");
        }


    }

    public async Task<Response<bool>> DeleteCategoryAsync(int id)
    {
          try
        {
            var res = await categoryRepository1.DeleteCategoryAsync(id);
            return res == true
            ? new Response<bool>(HttpStatusCode.OK, "deleted", res)
            : new Response<bool>(HttpStatusCode.OK, "smth went wrong", res);
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "Error while deleting category");
            return new Response<bool>(HttpStatusCode.InternalServerError, "Internal Server error");
        }
    }
    

    public async Task<Response<IEnumerable<CategoryDto>>> GetAllCategoriesAsync()
    {

        var res = await categoryRepository1.GelAllCategoryAsync();
        var data = res.Select(x => new CategoryDto
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            Created_At = x.CreatedAt
        }).ToList();
        return new Response<IEnumerable<CategoryDto>>(HttpStatusCode.OK, "List of category", data);
    }
    public async Task<Response<CategoryDto>> GetCategoryByIdAsync(int id)
    {
        var res = await categoryRepository1.GetByIdCategoryesAsync(id);
        var data = new CategoryDto
        {
            Id = res.Id,
            Name = res.Name,
            Description = res.Description,
            Created_At = res.CreatedAt
        };
        return new Response<CategoryDto>(HttpStatusCode.OK, "category by id", data);

    }
    public async Task<Response<bool>> UpdateCategoryAsync(UpdateCategoryDto category)
    {
           try
        {
            var c = new Category()
            {
            
                Name = category.Name,
                Description = category.Description!
            };
            var res = await categoryRepository1.UpdateCategoryAsync(c);
            return res == true
                ? new Response<bool>(HttpStatusCode.OK, "updated", res)
                : new Response<bool>(HttpStatusCode.OK, "smth went wrong", res);
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "Error while updating catgory");
            return new Response<bool>(HttpStatusCode.InternalServerError, "Internal server error");
        }



    }


internal interface ILogger
{
}
}