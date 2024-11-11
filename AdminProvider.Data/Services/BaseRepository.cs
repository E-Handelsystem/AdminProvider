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

    public ResponseResult<T> Update(T entity)
    {
        if (entity == null)
        {
            return ResponseFactory<T>.Failed(entity!);
        }

        // Förutsatt att FindIndex korrekt kan hitta objekt baserat på Equals
        var index = _items.FindIndex(e => e.Equals(entity));

        if (index >= 0)
        {
            _items[index] = entity;  // Uppdaterar det befintliga objektet
            return ResponseFactory<T>.Success(entity);  // Returnerar det uppdaterade objektet
        }

        return ResponseFactory<T>.NotFound(entity!, message: "Objektet kunde inte hittas för uppdatering.");
    }

    public ResponseResult<T> Delete(T entity)
    {
        // Kontrollera om vi hittar objektet i listan
        var index = _items.FindIndex(e => e.Equals(entity));  // Förutsatt att T implementerar Equals korrekt

        if (index >= 0)
        {
            // Ta bort objektet om det finns
            _items.RemoveAt(index);

            // Returnera en framgångsrespons med det borttagna objektet
            return ResponseFactory<T>.Success(entity);
        }

        // Om objektet inte finns, returnera en "Not Found"-respons
        return ResponseFactory<T>.NotFound(entity);
    }

}
