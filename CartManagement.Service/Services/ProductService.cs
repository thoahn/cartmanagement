using CartManagement.Core.Models;
using CartManagement.Core.Repositories;
using CartManagement.Core.Services;
using CartManagement.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartManagement.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork, IRepository<Product> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(int categoryId)
        {
            return await _unitOfWork.Products.GetProductsByCategoryIdAsync(categoryId);
        }

    }
}
