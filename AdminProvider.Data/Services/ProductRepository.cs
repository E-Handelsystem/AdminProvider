using AdminProvider.Data.Interfaces;

namespace AdminProvider.Data.Services;
public class ProductRepository<T> : BaseRepository<T>, IProductRepository<T>

{
    //Repository för produkter som skapas. Baserat på BaseRepository.
    //Här kan vi uttöka det vi vill spara ned vid varje produktsparning vid behov.
    // På så vis gör vi inga justeringar i BaseRepository utan gör modifieringar här utan att påverka basklassen.
}
