using CartManagement.API.Consts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CartManagement.API.DTOs
{
    public class CartDto
    {
        public int Id { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = ErrorConsts.RANGE_BETWEEN_1_MAX)]
        public int PersonId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = ErrorConsts.RANGE_BETWEEN_1_MAX)]
        public int ProductId { get; set; }

        public int Quantity { get; set; } = 1;


    }
}
