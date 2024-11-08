namespace AdminProvider.Domain.Models;
public class Product : ProductRequest

{
   public string Id { get; set; } = Guid.NewGuid().ToString();

}