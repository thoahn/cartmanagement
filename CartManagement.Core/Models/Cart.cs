using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartManagement.Core.Models
{
    public class Cart
    {
        public int ID { get; set; }
        public int PersonId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
