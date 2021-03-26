using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3B.Core.ViewModels
{
    public class SubSectionViewModel : BaseSubSectionViewModel
    {
        public BaseSectionViewModel Section { get; set; }
        public List<BaseServiceViewModel> Services { get; set; }
    }
}
