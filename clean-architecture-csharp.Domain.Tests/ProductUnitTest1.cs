using clean_architecture_csharp.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace clean_architecture_csharp.Domain.Tests;

public class ProductUnitTest1
{
     [Fact(DisplayName = "Create Product Successfully")]
     public void CreateProduct_WithValidParameters_ResultObjectValidState()
     {
          Action action = () => new Product(1, "TestProduct", "TestDescription", 9.99m, 99, "TestImage");
          action.Should().NotThrow<clean_architecture_csharp.Domain.Validation.DomainExceptionValidation> ();
     }

     [Fact(DisplayName = "Create Product Negative Id Value Domain Exception")]
     public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
     {
          Action action = () => new Product(-1, null, "TestDescription", 9.99m, 99, "TestImage");
          action.Should().Throw<clean_architecture_csharp.Domain.Validation.DomainExceptionValidation>()
               .WithMessage("Id cannot be less than zero.");
     }

     [Fact(DisplayName = "Create Product Short Name Value Domain Exception")]
     public void CreateProduct_ShortNameValue_DomainExceptionInvalidName()
     {
          Action action = () => new Product(1, "Pr", "TestDescription", 9.99m, 99, "");
          action.Should().Throw<clean_architecture_csharp.Domain.Validation.DomainExceptionValidation>()
               .WithMessage("Invalid name, too short, minimum 3 characters.");
     }

     [Fact(DisplayName = "Create Product Long Img Value Domain Exception")]
     public void CreateProduct_LongImgValue_DomainExceptionInvalidName()
     {
          Action action = () => new Product(1, "TestProduct", "TestDescription", 9.99m, 99, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut non convallis lacus. Nullam vel neque neque. Donec ullamcorper iaculis augue, at venenatis nibh blandit id. Praesent tortor mauris, imperdiet sit amet neque ut, blandit pretium velit. Cras ut ipsum non massa condimentum vulputate. Integer id ligula in tellus elementum efficitur. Cras quis ipsum non mauris placerat ultrices. Curabitur a tempus nisl, eleifend lacinia augue. Cras cursus lacinia metus ac ultrices. Suspendisse nec enim in risus cursus tincidunt eget in risus. Quisque pharetra libero in ornare imperdiet. Phasellus varius mi rutrum, rhoncus felis eget, interdum risus. Aenean pellentesque, mi non lobortis ullamcorper, odio risus cursus augue, maximus mattis nisi mauris et ante. Nulla aliquam ligula urna, quis congue leo pulvinar euismod.\n\nNullam non turpis aliquet, imperdiet sem in, efficitur justo. Quisque vehicula justo vel justo accumsan efficitur. Etiam euismod, enim blandit sollicitudin rhoncus, nisl magna molestie felis, sed porta enim arcu quis augue. Aliquam tellus ante, facilisis non elementum vitae, vulputate ut ligula. Aenean vel volutpat urna. Suspendisse consequat sed diam in laoreet. Nullam ac ex pulvinar, faucibus lacus in, ultricies quam.\n\nSed finibus erat a quam aliquet, ac imperdiet est faucibus. Donec sed gravida tellus. Etiam luctus molestie mi nec gravida. Aliquam erat volutpat. Nunc feugiat ac est sed sodales. Ut ornare at lacus sagittis sodales. Fusce eu tortor euismod, lacinia libero in, venenatis nisi. Ut efficitur velit sed leo tempus consequat.");
          action.Should().Throw<clean_architecture_csharp.Domain.Validation.DomainExceptionValidation>()
               .WithMessage("Image cannot be longer than 250 characters.");
     }

     [Fact(DisplayName = "Create Product Null Image Domain Exception")]
     public void CreateProduct_WithNullImage_DomainException()
     {
          Action action = () => new Product(1, "TestProduct", "testDescription", 9.99m, 99, null);
          action.Should().Throw<clean_architecture_csharp.Domain.Validation.DomainExceptionValidation>();
     }

     [Fact(DisplayName = "Create Product Null Product Null Reference Exception")]
     public void CreateProduct_WithNullImage_NullReferenceException()
     {
          Action action = () => new Product(1, "TestProduct", "testDescription", 9.99m, 99, null);
          action.Should().NotThrow<NullReferenceException>();
     }

     [Fact(DisplayName = "Create Product Empty Image Domain Exception")]
     public void CreateProduct_WithEmptyImage_DomainException()
     {
          Action action = () => new Product(1, "TestProduct",  "TestDescription", 9.99m, 99, string.Empty);
          action.Should().Throw<clean_architecture_csharp.Domain.Validation.DomainExceptionValidation>()
               .WithMessage("Image cannot be null or empty.");
     }
     
     // [Theory] - Usado quanto tem parametros dentro do metodo de teste
     [Theory(DisplayName = "Create Product Invalid Stock Value Domain Exception")]
     [InlineData(-5)]
     public void CreateProduct_WithInvalidStockValue_DomainExceptionNegativeValue(int stockValue)
     {
          Action action = () => new Product(1, "TestProduct",  "TestDescription", 9.99m, stockValue, "TestImage");
          action.Should().Throw<clean_architecture_csharp.Domain.Validation.DomainExceptionValidation>()
               .WithMessage("Invalid Stock Value.");
     }
     
     
}