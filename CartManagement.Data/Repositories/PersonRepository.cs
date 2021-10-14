using CartManagement.Core.Models;
using CartManagement.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartManagement.Data.Repositories
{
    internal class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }

        public CategoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
