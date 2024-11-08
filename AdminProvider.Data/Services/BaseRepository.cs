using AdminProvider.Data.Interfaces;
using AdminProvider.Domain.Factories;
using AdminProvider.Domain.Models;

namespace AdminProvider.Data.Services;

public abstract class BaseRepository<T> : IBaseRepository<T>
//Beslut att ha en BaseRepository för att på sikt kunna använda den till flera olika repositories (utöver produkt). Har grundfunktionalitet här, skapa, spara och hämta.
{
    private readonly List<T> _items = []; //Generell Lista här, typen av produkter/items kommer variera.
    public ResponseResult<T> Create(T entity)
   
    {
        _items.Add(entity);

        return ResponseFactory<T>.Success(entity);
    }

    public ResponseResult<IEnumerable<T>> GetAll()
    {
        return ResponseFactory<IEnumerable<T>>.Success(_items);
    }

    public ResponseResult<T> GetOne(Func<T, bool> predicate)
    {
        var entity = _items.FirstOrDefault(predicate);

        if (entity != null)
        {
            return ResponseFactory<T>.Success(entity);
        }
        return ResponseFactory<T>.NotFound(entity!);
    }

}
