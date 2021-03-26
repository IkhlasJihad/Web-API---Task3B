using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3B.Data.Models
{
    public class FileDbEntity 
    {
        public int Id { get; set; }
        [Required]
        public string FilePath { get; set; }
        public int ServiceId { get; set; }
        public ServiceDbEntity Service { get; set; }
    }
}
