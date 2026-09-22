using Application.Interfaces;
using Domain.ApieResponse;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class CategorySetvice : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategorySetvice(ICategoryRepository categoryRepository)
    {
        _categoryRepository=categoryRepository;
    }



    public Task<Response<Category>> CreateCategoryAsync(Category category)
    {
      
      
    }

    public Task<Response<string>> DeleteCategoryAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<IEnumerable<Category>>> GetAllCategoriesAsync()
    {
        var category=await _categoryRepository.GelAllCategoryAsync();
        return new Response<IEnumerable<Category>>(200,"Список категорий успешно получен",category);
    }

    public async Task<Response<Category>> GetCategoryByIdAsync(int id)
    
     {
        var category = await _categoryRepository.GetByIdCategoryesAsync(id);
        if (category == null)
        {
            return new Response<Category>(404, $"Категория с ID {id} не найдена");
        }

        return new Response<Category>(200, "Категория найдена", category);
    

    }

    public async Task<Response<string>> UpdateCategoryAsync(Category category)
    {
        
    }

}
