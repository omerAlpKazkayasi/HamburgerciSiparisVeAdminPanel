using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UserOrderDetailsDTO
    {
        public List<OrderDetailsWithProductNamesDTO> OrderDetailsWithProductNames { get; set; }
        public decimal TotalPrice { get; set; }
        public int OrderId { get; set; }
        public string UserId { get; set; }

        public DateTime CreateDate { get; set; }


    }
}
