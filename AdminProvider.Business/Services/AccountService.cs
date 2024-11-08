using AdminProvider.Business.Interfaces;
using AdminProvider.Domain.Factories;
using AdminProvider.Domain.Models;

namespace AdminProvider.Business.Services;

public class AccountService : IAccountService
{
    public ResponseResult<AdminAccount> CreateAdminAccount(Account account)
    {
        try
        {

            var adminaccount = new AdminAccount

            {
                FirstName = account.FirstName,
                LastName = account.LastName,
                Email = account.Email,
                Password = account.Password,
                IsAdmin = true,

            };

            return ResponseFactory<AdminAccount>.Success(adminaccount);
        }
        catch
        {
            return ResponseFactory<AdminAccount>.Failed(null!);
        }
       
        }
       
    



    public ResponseResult DeleteOne(AdminAccount Id)
    {
        throw new NotImplementedException();
    }

    public ResponseResult<AdminAccount> GetOne(AdminAccount Id)
    {
        throw new NotImplementedException();
    }

    public ResponseResult<AdminAccount> UpdateOne(AdminAccount Id)
    {
        throw new NotImplementedException();
    }
}
