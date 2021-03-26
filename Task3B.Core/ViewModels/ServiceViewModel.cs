using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3B.Core.ViewModels
{
    public class ServiceViewModel : BaseServiceViewModel
    {
        public BaseSubSectionViewModel SubSection { get; set; }
        public BaseServiceProviderViewModel Provider { get; set; }
        public List<string> Files { get; set; }

    }
}
