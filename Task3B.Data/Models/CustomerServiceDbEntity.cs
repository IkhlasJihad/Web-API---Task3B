using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3B.Data.Models
{
    public class CustomerServiceDbEntity 
    {
        public int CustomerId { get; set; }
        public CustomerDbEntity Customer { get; set; }
        public int ServiceId { get; set; }
        public ServiceDbEntity Service { get; set; }

        public DateTime OrderDate { get; set; }
        public double Price { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
