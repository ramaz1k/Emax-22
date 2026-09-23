namespace Application.DTO.CategoryDTO;

public class CategoryDto
{
    public int Id{get;set;}
    public string Name{get;set;} = string.Empty;
    public string? Description{get;set;}
    public DateTime Created_At{get;set;}
}
