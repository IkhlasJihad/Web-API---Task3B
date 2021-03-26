using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3B.Core.DTOs;
using Task3B.Core.ViewModels;

namespace Task3B.Service.Services.SubSection
{
    public interface ISubSectionService
    {
        List<SubSectionViewModel> GetAll(int pageNum);
        void Delete(int id);

        void Create(CreateSubSectionDTO dto);
        void Update(UpdateSubSectionDTO dto);
    }
}
