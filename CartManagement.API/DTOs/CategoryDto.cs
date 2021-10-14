using CartManagement.API.Consts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CartManagement.API.DTOs
{
    public class CategoryDto
    {
        [Required(ErrorMessage = ErrorConsts.GENERAL_REQUIRED)]
        public int Id { get; set; }

        [Required(ErrorMessage = ErrorConsts.GENERAL_REQUIRED)]
        public string Name { get; set; }
    }
}
