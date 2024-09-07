using clean_architecture_csharp.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace clean_architecture_csharp.Domain.Tests;

public class CategoryUnitTest1
{
    [Fact(DisplayName = "Create Category Successfully")]
    public void CreateCategory_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Category(1, "Category Name");
        action.Should()
            .NotThrow<clean_architecture_csharp.Domain.Validation.DomainExceptionValidation>();
    }
    
    [Fact(DisplayName = "Create Category With Null Name")]
    public void CreateCategory_WithNullNameValue_DomainExceptionInvalidId()
    {
        Action action = () => new Category(-1, "Category Name");
        action.Should()
            .Throw<clean_architecture_csharp.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Id cannot be less than zero.");
    }

    [Fact(DisplayName = "Create Category With Empty Name")]
    public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
    {
        Action action = () => new Category(1, null);
        action.Should()
            .Throw<clean_architecture_csharp.Domain.Validation.DomainExceptionValidation>();
    }
    

    [Fact(DisplayName = "Create Category With Empty Description")]
    public void CreateCategory_MissingNameValue_DomainExceptionRequireName()
    {
        Action action = () => new Category(1, "");
        action.Should()
            .Throw<clean_architecture_csharp.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Name cannot be null or empty.");
    }
    
    [Fact(DisplayName = "Create Category With Empty Description")]
    public void CreateCategory_ShortNameValue_DomainExceptionShortName()
    {
        Action action = () => new Category(1, "Ca");
        action.Should()
            .Throw<clean_architecture_csharp.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Name too short, minimum 3 characters.");
    }

    
}