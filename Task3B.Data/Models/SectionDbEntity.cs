using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3B.Data.Models
{
    public class SectionDbEntity : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public List<SubSectionDbEntity> SubSections { get; set; }

    }
}
