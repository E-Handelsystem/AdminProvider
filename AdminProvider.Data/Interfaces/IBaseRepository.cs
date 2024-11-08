using AdminProvider.Domain.Models;

namespace AdminProvider.Data.Interfaces
{
    public interface IBaseRepository<T>
    {
        ResponseResult<T> Create(T entity);
        ResponseResult<IEnumerable<T>> GetAll();
        ResponseResult<T> GetOne(Func<T, bool> predicate);
    }
}