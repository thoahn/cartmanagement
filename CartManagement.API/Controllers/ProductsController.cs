using AutoMapper;
using CartManagement.API.DTOs;
using CartManagement.API.Filters;
using CartManagement.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
        }

        [ServiceFilter(typeof(ProductNotFoundFilter))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            return Ok(_mapper.Map<ProductDto>(product));
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetProductsByCategoryIdAsync(int categoryId)
        {
            var products = await _productService.GetProductsByCategoryIdAsync(categoryId);

            return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
        }
    }
}
