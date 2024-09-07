using clean_architecture_csharp.Domain.Entities;

namespace clean_architecture_csharp.Domain.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProductsAsync();
    Task<Product> GetProductByIdAsync(int? id);
    
    Task<Product> GetProductCategoryAsync(int? categoryId);
    
    Task<Product> CreateProductAsync(Product product);
    Task<Product> UpdateProductAsync(Product product);
    Task<Product> DeleteProductAsync(Product product);
}