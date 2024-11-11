
using AdminProvider.Business.Interfaces;
using AdminProvider.Data.Interfaces;
using AdminProvider.Domain.Factories;
using AdminProvider.Domain.Models;

namespace AdminProvider.Business.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository<Product> _productRepository;

    public ProductService(IProductRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }



    public ResponseResult<Product> Create(ProductRequest productRequest)
    {
        var product = ProductFactory.Create(productRequest);
        var result = _productRepository.Create(product);

        if (string.IsNullOrWhiteSpace(product.Name) || string.IsNullOrWhiteSpace(product.Price))

            return ResponseFactory<Product>.Failed(result.Data!);


        else if (result.Success)
        {
            return ResponseFactory<Product>.Success(result.Data!);
        }

        return ResponseFactory<Product>.NotFound(result.Data!);
    }

    public ResponseResult<IEnumerable<Product>> GetAll()
    {
        throw new NotImplementedException();
    }

    public ResponseResult<Product> GetOne(string id)
    {
        throw new NotImplementedException();
    }

    public ResponseResult<Product> Update(string id, ProductRequest productRequest)
    {
        // Hämta produkten som ska uppdateras baserat på ID
        var result = _productRepository.GetOne(p => p.Id == id);

        // Kontrollera om produkten hittades
        if (!result.Success || result.Data == null)
        {
            return ResponseFactory<Product>.NotFound(null);
        }

        var existingProduct = result.Data;

        // Uppdatera produktens egenskaper med nya värden från productRequest
        existingProduct.Name = productRequest.Name;
        existingProduct.Description = productRequest.Description;
        existingProduct.Price = productRequest.Price;

        // Kalla på repositoryt för att uppdatera produktinformationen
        var updateResult = _productRepository.Update(existingProduct);

        // Kontrollera om uppdateringen lyckades och returnera resultatet
        if (updateResult.Success)
        {
            return ResponseFactory<Product>.Success(updateResult.Data!);
        }

        return ResponseFactory<Product>.Failed(existingProduct);
    }


    public ResponseResult<Product> Delete(string id)
    {
        // Hämta produkten baserat på ID
        var result = _productRepository.GetOne(p => p.Id == id);

        // Om produkten inte hittades, returnera NotFound
        if (!result.Success)
        {
            return ResponseFactory<Product>.NotFound(null);
        }

        var productToDelete = result.Data;

        // Anropa repositoryt för att ta bort produkten
        var deleteResult = _productRepository.Delete(productToDelete);

        // Returnera resultatet från Delete-operationen
        return ResponseFactory<Product>.Success(deleteResult.Data!);
    }

}
