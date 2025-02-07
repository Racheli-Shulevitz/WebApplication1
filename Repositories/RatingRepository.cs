using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RatingRepository : IRatingRepository
    {
        OurStoreContext context;

        public RatingRepository(OurStoreContext _context)
        {
            context = _context;
        }
        //POST
        public async Task<Rating> Post(Rating rating)
        {
            await context.AddAsync(rating);
            await context.SaveChangesAsync();

            return rating;

        }
    }
}
