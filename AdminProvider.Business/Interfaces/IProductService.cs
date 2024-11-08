
using AdminProvider.Domain.Models;

namespace AdminProvider.Business.Interfaces;

public interface IProductService
{
    public ResponseResult<Product> Create(ProductRequest productRequest);
    public ResponseResult<IEnumerable<Product>> GetAll();
    public ResponseResult<Product> GetOne(string Id);

    public ResponseResult<Product> UpdateOne(string Id);

    public ResponseResult DeleteOne(string Id);


}

