using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3B.Data.Models
{
    public class  ServiceDbEntity : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int SubSectionId { get; set; }
        public SubSectionDbEntity SubSection { get; set; }
        public List<CustomerServiceDbEntity> CustomerServices { get; set; }

        public int ServiceProviderId { get; set; }
        public ServiceProviderDbEntity ServiceProvider { get; set; }

        public List<FileDbEntity> Files { get; set; }

    }

}
