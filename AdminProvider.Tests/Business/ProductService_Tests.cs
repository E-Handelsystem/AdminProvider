
using AdminProvider.Business.Interfaces;
using AdminProvider.Business.Services;
using AdminProvider.Data.Interfaces;
using AdminProvider.Data.Services;
using AdminProvider.Domain.Factories;
using AdminProvider.Domain.Models;
using Moq;

namespace AdminProvider.Tests.Business;

public class ProductService_Tests
{
    private readonly IProductService _productService;
    private readonly Mock<IProductRepository<Product>> _productRepositoryMock;
    public ProductService_Tests()
    {
        _productRepositoryMock = new Mock<IProductRepository<Product>>();
        _productService = new ProductService(_productRepositoryMock.Object);
    }


    [Fact]
    public void Should_Return_ResponseResultSuccess_WhenProductIsCreated()
    {
        //Arrange
        var productRequest = new ProductRequest
        {
            Name = "Skjorta",
            Description = "En rutig skjorta i stretch. Ett toppenköp.",
            Price = "599"
        };

        var createdProduct = ProductFactory.Create(productRequest);

        //Stöd från ChatGpt och google med nedan stycke (hur mocka productRepository):
        _productRepositoryMock
            .Setup(repo => repo.Create(It.IsAny<Product>()))
            .Returns(ResponseFactory<Product>.Success(createdProduct));

        //Act
        var result = _productService.Create(productRequest);
        
        //Assert

        Assert.NotNull(result);
        Assert.True(result.Success);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal("Allt har gått bra!", result.Message);

    }

    [Fact]
    public void Should_Return_ResponseResultFailed_WhenNameIsMissing_AndProductCreationFail()
    {
        //Arrange
        var productRequest = new ProductRequest
        {
            Name = null!,
            Description = "Ett par sköna byxor",
            Price = "199"
        };

        _productRepositoryMock
            .Setup(repo => repo.Create(It.IsAny<Product>()))
            .Returns(ResponseFactory<Product>.Failed(null!));

        //Act

        var result = _productService.Create(productRequest);

        //Assert

        Assert.NotNull(result);
        Assert.False(result.Success);
        Assert.Equal(400, result.StatusCode);
        Assert.Null(result.Data);

    }

    [Fact]
    public void Should_Update_Product_When_Exists()
    {
        // Arrange
        var productRequest = new ProductRequest
        {
            Name = "Skjorta",
            Description = "En rutig skjorta i stretch. Ett toppenköp.",
            Price = "599"
        };

        // Använd factory för att skapa produkten med ett genererat ID
        var createdProduct = ProductFactory.Create(productRequest);

        //Samlat alla Repository-mocks i en gemensam privat metod
        SetupRepositoryMocks(createdProduct);

        // Act
        // Anropa ProductService.Create för att skapa produkten
        var createResult = _productService.Create(productRequest);

        // Kontrollera att Create var framgångsrikt
        Assert.NotNull(createResult);
        Assert.True(createResult.Success);
        Assert.Equal("Skjorta", createResult.Data!.Name);

        // Ändra egenskaperna på produkten och förbered en Update-request
        var updateRequest = new ProductRequest
        {
            Name = "Uppdaterad Skjorta",
            Description = "En rutig skjorta med ny stil.",
            Price = "99"
        };

        // Anropa ProductService.Update med den nya requesten
        var updateResult = _productService.Update(createResult.Data.Id, updateRequest);

        // Kontrollera att Update var framgångsrikt
        Assert.NotNull(updateResult);
        Assert.NotNull(updateResult.Data);
        Assert.True(updateResult.Success);
        Assert.Equal("99", updateResult.Data.Price);
    }

    [Fact]
    public void Should_Delete_Product_When_Exists()
    {
        // Arrange
        var productRequest = new ProductRequest
        {
            Name = "Skjorta",
            Description = "En rutig skjorta i stretch. Ett toppenköp.",
            Price = "599"
        };

        // Använd factory för att skapa produkten med ett genererat ID
        var createdProduct = ProductFactory.Create(productRequest);

        //Samlat alla Repository-mocks i en gemensam privat metod
        SetupRepositoryMocks(createdProduct);

        // Act
        // Anropa ProductService.Create för att skapa produkten
        var createResult = _productService.Create(productRequest);

        // Kontrollera att Create var framgångsrikt
        Assert.NotNull(createResult);
        Assert.True(createResult.Success);
        Assert.Equal("Skjorta", createResult.Data!.Name);

        // Anropa ProductService.Delete med det skapade produktens ID
        var deleteResult = _productService.Delete(createResult.Data.Id);

        // Kontrollera att Delete var framgångsrikt
        Assert.NotNull(deleteResult);
        Assert.True(deleteResult.Success);
        Assert.Equal("Skjorta", deleteResult.Data!.Name);  // Kontrollera att rätt produkt togs bort

        // Kontrollera att produkten nu inte finns i repositoryt med hjälp av ChatGPT
        _productRepositoryMock
            .Verify(repo => repo.Delete(It.Is<Product>(p => p.Id == createResult.Data.Id)), Times.Once);  // Kontrollera att Delete anropades en gång
    }

    private void SetupRepositoryMocks(Product createdProduct) //Hjälp av ChatGPT
    {
        // Mocka Create så att det returnerar createdProduct
        _productRepositoryMock
            .Setup(repo => repo.Create(It.IsAny<Product>()))
            .Returns(ResponseFactory<Product>.Success(createdProduct));

        // Mocka GetOne så att den returnerar createdProduct när ett ID matchar
        _productRepositoryMock
            .Setup(repo => repo.GetOne(It.Is<Func<Product, bool>>(predicate => predicate.Invoke(createdProduct))))
            .Returns(ResponseFactory<Product>.Success(createdProduct));

        // Mocka Update så att det returnerar en uppdaterad version av produkten
        _productRepositoryMock
            .Setup(repo => repo.Update(It.IsAny<Product>()))
            .Returns((Product updatedProduct) => ResponseFactory<Product>.Success(updatedProduct));

        // Mocka Delete så att det returnerar success när produkten tas bort
        _productRepositoryMock
            .Setup(repo => repo.Delete(It.IsAny<Product>()))
            .Returns((Product productToDelete) => ResponseFactory<Product>.Success(productToDelete));
    }
}


