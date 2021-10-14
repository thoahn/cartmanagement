using CartManagement.API.Consts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CartManagement.API.DTOs
{
    public class PersonDto
    {
        [Required(ErrorMessage = ErrorConsts.GENERAL_REQUIRED)]
        public int ID { get; set; }

        [Required(ErrorMessage = ErrorConsts.GENERAL_REQUIRED)]
        public string Name { get; set; }

        [Required(ErrorMessage = ErrorConsts.GENERAL_REQUIRED)]
        public string SurName { get; set; }
    }
}
