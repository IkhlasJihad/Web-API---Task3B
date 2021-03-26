using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3B.Core.ViewModels
{
    public class ServiceProviderViewModel : BaseServiceProviderViewModel
    {
        public List<BaseServiceViewModel> Services { get; set; }
    }
}
