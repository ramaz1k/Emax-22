using Domain.Models;

namespace Domain.Interfaces;

public interface ICategoryRepository
{
   Task <bool> CreateCategoryAsync(Category category);
   Task <List<Category>> GelAllCategoryAsync(); 
   Task <bool>UpdateCategoryAsync(Category category);
   Task<bool>DeleteCategoryAsync(int Id);
   Task<Category?>GetByIdCategoryesAsync(int Id);
}
