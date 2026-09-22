using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositoryes;

public class ProductRepository(DataContext dataContext) : IProductRepository
{

    private readonly DataContext _context = dataContext;


    public async Task<bool> CreateProductAsync(Product product)
    {
        using var conn = _context.GetConnection();
        var query = "Insert into Product (CategoryId ,Name,Description,Price,Quantity,CreatedAt) values(@categoryId,@name,@description,@price,@quantity,@createdAt);";
        var res = await conn.ExecuteAsync(query, product);
        return res > 0;
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        using var conn = _context.GetConnection();
        var query = "delete from Product where id = @Id;";
        var res = await conn.ExecuteAsync(query, new { Id = id });
        return res > 0;
    }

    public async Task<List<Product>> GetAllProductsAsync()
    {
        var conn=_context.GetConnection();
        var query="Select * from Product";
        var list=await conn.QueryAsync<Product>(query);
        return list.ToList();
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        var conn=_context.GetConnection();
        var query="select * from Product where id=@Id";
      return await conn.QueryFirstOrDefaultAsync<Product>(query, new { Id = id });
    }

    public async Task<bool> UpdateProductAsync(Product product)
    {
      var conn=_context.GetConnection();
      var query= @"update Product set CategoryId = @categoryId, Name = @name,Description = @description,  Price = @price ,Quantity=@quantity ,CreatedAt=@createdAt where id = @Id;";
        var res=await conn.ExecuteAsync(query,product);
        return res>0;
    }

}
