using CartManagement.Core.Models;
using CartManagement.Core.Repositories;
using CartManagement.Core.Services;
using CartManagement.Core.UnitOfWorks;
using CartManagement.Service.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartManagement.Service.Services
{
    public class CartService : Service<Cart>, ICartService
    {
        public CartService(IUnitOfWork unitOfWork, IRepository<Cart> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<IEnumerable<Cart>> GetProductsByPersonIdAsync(int personId)
        {
            return await _unitOfWork.CartProducts.GetProductsByPersonIdAsync(personId);
        }

        public override async Task<Cart> AddAsync(Cart entity)
        {
            //product check
            var product = await _unitOfWork.Products.GetByIdAsync(entity.ProductId);
            if (product == null)
                throw new Exception(ErrorConsts.PRODUCT_NOT_FOUND);

            //stock check
            if(entity.Quantity > product.Stock)
                throw new Exception(ErrorConsts.STOCK_OVER);

            //person check
            var person = await _unitOfWork.Persons.GetByIdAsync(entity.PersonId);
            if (person == null)
                throw new Exception(ErrorConsts.PERSON_NOT_FOUND);

            //quantity update
            product.Stock = product.Stock - entity.Quantity;
            _unitOfWork.Products.Update(product);


            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();

            return entity;

        }
    }
}
