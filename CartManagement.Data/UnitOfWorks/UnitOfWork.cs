using CartManagement.Core.Repositories;
using CartManagement.Core.UnitOfWorks;
using CartManagement.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartManagement.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        private ProductRepository _productRepository;
        private CategoryRepository _categoryRepository;
        private CartRepository _cartRepository;
        private PersonRepository _personRepository;

        public IProductRepository Products => _productRepository = _productRepository ?? new ProductRepository(_context);

        public ICategoryRepository Categories => _categoryRepository = _categoryRepository ?? new CategoryRepository(_context);

        public ICartRepository CartProducts => _cartRepository = _cartRepository ?? new CartRepository(_context);

        public IPersonRepository Persons => _personRepository = _personRepository ?? new PersonRepository(_context);

        public UnitOfWork(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
