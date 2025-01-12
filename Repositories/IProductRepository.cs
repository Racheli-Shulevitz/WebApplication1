using Entities;

namespace Repositories
{
    public interface IProductRepository
    {
        //Task<Product> Get(int id);//
        Task<List<Product>> Get(string? desc, int? minPrice, int? maxPrice, int?[] categoryIds);
        //Task<Product> Post(Product product);
        //Task<Product> Put(int id, Product productToUpdate);
    }
}