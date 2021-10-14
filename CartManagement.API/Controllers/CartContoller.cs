using AutoMapper;
using CartManagement.API.DTOs;
using CartManagement.API.Filters;
using CartManagement.Core.Models;
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
    public class CartController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICartService _cartService;

        public CartController(ICartService cartService, IMapper mapper)
        {
            _cartService = cartService;
            _mapper = mapper;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var cart = await _cartService.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<CartDto>>(cart));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cart = await _cartService.GetByIdAsync(id);

            return Ok(_mapper.Map<CartDto>(cart));
        }

        [HttpGet("person/{personId}")]
        public async Task<IActionResult> GetProductsByPersonIdAsync(int personId)
        {
            var cart = await _cartService.GetProductsByPersonIdAsync(personId);

            return Ok(_mapper.Map<IEnumerable<CartDto>>(cart));
        }

        [HttpPost("addtocart")]
        public async Task<IActionResult> Save(CartDto cartDto)
        {
            var newCart = await _cartService.AddAsync(_mapper.Map<Cart>(cartDto));

            return Created(string.Empty, _mapper.Map<CartDto>(newCart));
        }
    }
}
