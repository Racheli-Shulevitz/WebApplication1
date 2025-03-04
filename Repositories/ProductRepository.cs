using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        OurStoreContext context;
        public ProductRepository(OurStoreContext _context)
        {
            context = _context;
        }
  

        public async Task<List<Product>> Get(string? desc, int? minPrice, int? maxPrice, int?[] categoryIds)
        {

            var query = context.Products.Where(product =>
                (desc == null ? (true) : (product.Description.Contains(desc)))
                && ((minPrice == null) ? (true) : (product.Price >= minPrice))
                && ((maxPrice == null) ? (true) : (product.Price <= maxPrice))
                && ((categoryIds.Length == 0) ? (true) : (categoryIds.Contains(product.CategoryId))))
               .OrderBy(product => product.Price).Include(c => c.Category);
            Console.WriteLine(query.ToQueryString());
            List<Product> products = await query.ToListAsync();
            return products;
        }
        //
        //get by id
        public async Task<Product> Get(int id)
        {
            return await context.Products.FirstOrDefaultAsync(item => item.ProductId == id);
        }

        //add
        //public async Task<Product> Post(Product product)
        //{
        //    await context.Products.AddAsync(product);
        //    await context.SaveChangesAsync();
        //    return product;
        //}

        ////update
        //public async Task<Product> Put(int id, Product productToUpdate)
        //{
        //    // productToUpdate.ProductId = id;
        //    context.Products.Update(productToUpdate);
        //    await context.SaveChangesAsync();
        //    return productToUpdate;
        //}
    }
}
