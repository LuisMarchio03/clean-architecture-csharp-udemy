using clean_architecture_csharp.Domain.Entities;

namespace clean_architecture_csharp.Domain.Interfaces;

public interface ICategoryRepository
{
    // Task - define um metodo async
    Task<IEnumerable<Category>> GetCategoriesAsync();    
    Task<Category> GetCategoryByIdAsync(int? id);
    
    Task<Category> CreateCategoryAsync(Category category);
    Task<Category> UpdateCategoryAsync(Category category);
    Task DeleteCategoryAsync(Category category);
    
}