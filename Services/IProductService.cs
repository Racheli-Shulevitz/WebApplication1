using Entities;

namespace Services
{
    public interface IProductService
    {
        Task<List<Product>> Get(string? desc, int? minPrice, int? maxPrice, int?[] categoryIds);
        Task<Product> Get(int id);
        //Task<Product> Post(Product product);
        //Task<Product> Put(int id, Product product);//
    }
}