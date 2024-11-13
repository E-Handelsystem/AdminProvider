using AdminProvider.Domain.Models;

namespace AdminProvider.Business.Interfaces;

public interface IAccountService
{
    public ResponseResult<AdminAccount> CreateAdminAccount(Account account);

    public ResponseResult<AdminAccount> GetOne(AdminAccount Id);

    public ResponseResult<AdminAccount> UpdateOne(AdminAccount Id);

    public ResponseResult DeleteOne(AdminAccount Id);


}

