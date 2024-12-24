using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Services
{
    public class ProductService : IProductService
    {
        IProductRepository productRepository;
        public ProductService(IProductRepository _productRepository)
        {
            productRepository = _productRepository;
        }

        //get all
        public Task<List<Product>> Get(string? desc, int? minPrice, int? maxPrice, int?[] categoryIds)
        {
            return productRepository.Get(desc, minPrice, maxPrice, categoryIds);
        }

        //get by id
        //public Task<Product> Get(int id)
        //{
        //    return productRepository.Get(id);
        //}

        ////add
        //public async Task<Product> Post(Product product)
        //{
        //    return await productRepository.Post(product);
        //}

        ////update
        //public Task<Product> Put(int id, Product product)
        //{
        //    return productRepository.Put(id, product);
        //}
        ////delete
        //public Task<Product>
    }
}
