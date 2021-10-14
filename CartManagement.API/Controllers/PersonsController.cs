using AutoMapper;
using CartManagement.API.DTOs;
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
    public class PersonsController : ControllerBase
    {
        private readonly IService<Person> _personService;
        private readonly IMapper _mapper;

        public PersonsController(IService<Person> service, IMapper mapper)
        {
            _personService = service;
            _mapper = mapper;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var persons = await _personService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<PersonDto>>(persons));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var person = await _personService.GetByIdAsync(id);
            return Ok(_mapper.Map<PersonDto>(person));
        }
    }
}
