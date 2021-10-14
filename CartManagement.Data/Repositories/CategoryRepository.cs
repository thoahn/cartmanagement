using CartManagement.Core.Models;
using CartManagement.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartManagement.Data.Repositories
{
    internal class PersonRepository : Repository<Person>, IPersonRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }

        public PersonRepository(AppDbContext context) : base(context)
        {
        }
    }
}
