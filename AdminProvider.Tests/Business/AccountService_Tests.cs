using AdminProvider.Business.Interfaces;
using AdminProvider.Business.Services;
using AdminProvider.Domain.Factories;
using AdminProvider.Domain.Models;

namespace AdminProvider.Tests.Business;

public class AccountService_Tests 
{
    private readonly IAccountService _accountService;

    public AccountService_Tests()
        {
        _accountService = new AccountService(); 
    }

    [Fact]
    public void Should_Return_ResponseResultSuccess_WhenAdminAccountIsCreatedAndConfirmIsAdminIsTrue()
    {
        //Arrange
        var account = new Account
        {
            FirstName = "Gunnar",
            LastName = "Höök",
            Email = "gh@mail.com",
            Password = "123ABC",
         
        };

        // Act
        var result = _accountService.CreateAdminAccount(account);

        //Assert
        Assert.NotNull(result);
        Assert.True(result.Success);
        Assert.Equal(200, result.StatusCode);
        Assert.IsType<AdminAccount>(result.Data);
        Assert.True(result.Data.IsAdmin);
 

    }



}
