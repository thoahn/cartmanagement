using CartManagement.Core.Models;
using CartManagement.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartManagement.Data.Repositories
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }

        public CartRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Cart>> GetProductsByPersonIdAsync(int personId)
        {
            return await _appDbContext.CartProducts.Where(x => x.PersonId == personId).ToListAsync();
        }
    }
}
