using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3B.Core.ViewModels
{
    public class CustomerServiceViewModel
    {
        public CustomerViewModel Customer { get; set; }
        public BaseServiceViewModel Service { get; set; }

        public DateTime OrderDate { get; set; }
        public double Price { get; set; }
    }
}
