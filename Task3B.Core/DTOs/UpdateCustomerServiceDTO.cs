using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3B.Core.DTOs
{
    public class UpdateCustomerServiceDTO
    {
        public int CustomerId { get; set; }
        public int ServiceId { get; set; }
        public DateTime OrderDate { get; set; }
        public double Price { get; set; }
    }
}
