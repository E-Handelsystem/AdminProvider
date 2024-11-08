
using AdminProvider.Business.Interfaces;
using AdminProvider.Business.Services;
using AdminProvider.Data.Interfaces;
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


}


