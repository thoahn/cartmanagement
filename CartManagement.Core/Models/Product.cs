using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartManagement.Core.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public int Stock { get; set; }
        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public bool IsDeleted { get; set; }


    }
}
