using CartManagement.API.Consts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CartManagement.API.DTOs
{
    public class ProductDto
    {
        [Required(ErrorMessage = ErrorConsts.GENERAL_REQUIRED)]
        public int Id { get; set; }

        [Required(ErrorMessage = ErrorConsts.GENERAL_REQUIRED)]
        public string Name { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = ErrorConsts.RANGE_BETWEEN_1_MAX)]
        public int Stock { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = ErrorConsts.RANGE_BETWEEN_1_MAX)]
        public decimal Price { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = ErrorConsts.RANGE_BETWEEN_1_MAX)]
        public int CategoryId { get; set; }
    }
}
