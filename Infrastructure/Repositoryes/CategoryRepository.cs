using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Dapper;

namespace Infrastructure.Repositoryes;

public class CategoryRepository (DataContext dataContext) : ICategoryRepository
{

    private readonly DataContext _context=dataContext;
    public async Task<bool> CreateCategoryAsync(Category category)
    {

        using var conn = _context.GetConnection();
        var query = "Insert into Category ( Name,Description,CreatedAt) values(@name,@description,@createdAt);";
        var res = await conn.ExecuteAsync(query, category);
        return res > 0; 
           }

    public async Task<bool> DeleteCategoryAsync(int Id)
    {
        using var conn = _context.GetConnection();
        var query = "delete from Category where id = @id;";
        var res = await conn.ExecuteAsync(query, new { id = Id });
        return res > 0;
    }

    public async Task<List<Category>> GelAllCategoryAsync()
   {
        var conn=_context.GetConnection();
        var query="Select * from Category";
        var list=await conn.QueryAsync<Category>(query);
        return list.ToList();
    }

    public async Task<Category?> GetByIdCategoryesAsync(int Id)
     {
        var conn=_context.GetConnection();
        var query="select * from Category where id=@id";
      return await conn.QueryFirstOrDefaultAsync<Category>(query, new { id = Id });
    }

    public async Task<bool> UpdateCategoryAsync(Category category)
    {
         var conn=_context.GetConnection();
      var query= @"update Category set  Name = @name,Description = @description,CreatedAt=@createdAt where id = @Id;";
        var res=await conn.ExecuteAsync(query,category);
        return res>0;
    }

}
