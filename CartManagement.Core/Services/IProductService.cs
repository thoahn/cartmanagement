using CartManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartManagement.Core.Services
{
    public interface IProductService : IService<Product>
    {
        Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(int categoryId);
    }
}
