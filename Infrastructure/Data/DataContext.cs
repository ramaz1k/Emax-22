namespace Infrastructure.Data;
using Npgsql;

public class DataContext
{
 private readonly string _connectostring="Host=localhost;Port=5432;Database=product_store_db;Password=1234;Username=postgres";
public NpgsqlConnection GetConnection()
    {
        return new NpgsqlConnection(_connectostring);
    }
    
}
