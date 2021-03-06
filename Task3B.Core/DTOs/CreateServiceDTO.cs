using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3B.Core.DTOs
{
    public class CreateServiceDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int SubSectionId { get; set; }

        public int ServiceProviderId { get; set; }

        public List<IFormFile> Files { get; set; }
    }
}
