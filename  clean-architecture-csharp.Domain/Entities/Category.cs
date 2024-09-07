using clean_architecture_csharp.Domain.Validation;

namespace clean_architecture_csharp.Domain.Entities;

// Sealed - a classe não pode mais ser herdada
public sealed class Category : Entity
{ 
    public string Name { get; private set; }

    public Category(string name)
    {
        ValidationDomain(name);
    }

    public Category(int id, string name)
    {
        DomainExceptionValidation.When(id < 0, "Id cannot be less than zero.");
        Id = id;
        ValidationDomain(name);
    }

    public void Update(string name)
    {
        ValidationDomain(name);
    }
    
    private void ValidationDomain(string name)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Name cannot be null or empty.");
        
        DomainExceptionValidation.When(name.Length < 3, "Name too short, minimum 3 characters.");
        
        Name = name;
    }
    
    public ICollection<Product> Products { get; set; }
}