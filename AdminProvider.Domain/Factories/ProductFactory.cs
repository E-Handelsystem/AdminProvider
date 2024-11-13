
using AdminProvider.Domain.Models;

namespace AdminProvider.Domain.Factories;

public static class ProductFactory //Ha som ansvar att omvandla produktmodeller
{
    public static Product Create(ProductRequest productRequest) //Skickar in en product request får ut en Product
    {
        try
        {
            var product = new Product
            {
                Name = productRequest.Name,
                Description = productRequest.Description,
                Price = productRequest.Price,
            };
           
            return product;
        }
        catch 
        { 
            return null!; 
        }
    }
}
