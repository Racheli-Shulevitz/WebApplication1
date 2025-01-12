using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        OurStoreContext context;
        public CategoryRepository(OurStoreContext _context)
        {
            context = _context;
        }
        //get all
        public async Task<List<Category>> Get()
        {
            return await context.Categories.ToListAsync();
        }
        //
        //get by id
        //public async Task<Category> Get(int id)
        //{
        //    return await context.Categories.FirstOrDefaultAsync<Category>(item => item.CategoryId == id);
        //}
    }
}
