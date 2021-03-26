using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3B.Data.Models
{
    public class SubSectionDbEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int SectionId { get; set; }
        public SectionDbEntity Section { get; set; }
        public List<ServiceDbEntity> Services { get; set; }
    }
}
