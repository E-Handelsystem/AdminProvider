using AdminProvider.Domain.Factories;
using AdminProvider.Domain.Models;


namespace AdminProvider.Tests.Domain;

public class ResponseFactory_Tests
{

    [Fact]
    public void IfSuccess_ShouldReturnTrue()
    {
        //Act
       
        var result = ResponseFactory.Success();

        //Assert     
        Assert.True(result.Success);
    }

    [Fact]
    public void IfFailed_ShouldReturnFalseAndStatusCode400()
    {
        //Act

        var result = ResponseFactory.Failed();

        //Assert     
        Assert.False(result.Success);
        Assert.Equal(400, result.StatusCode);
    }

    [Fact]
    public void IfNotFound_ShouldReturnFalseAndStatusCode404()
    {
        //Act

        var result = ResponseFactory.NotFound();

        //Assert     
        Assert.False(result.Success);
        Assert.Equal(404, result.StatusCode);
    }

    [Fact]
    public void IfAlreadyExists_ShouldReturnFalseAndStatusCode409()
    {
        //Act

        var result = ResponseFactory.AlreadyExists();

        //Assert     
        Assert.False(result.Success);
        Assert.Equal(409, result.StatusCode);
    }

    [Fact]
    public void IfSuccess_ShouldReturnTrueAndDataAsProduct()
    {
        //Arrange
        var product = new Product();

        //Act

        var result = ResponseFactory<Product>.Success(data: product);

        //Assert     
        Assert.True(result.Success);
        Assert.IsType<Product>(result.Data);
    }

}
