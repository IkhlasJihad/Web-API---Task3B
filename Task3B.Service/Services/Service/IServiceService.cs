using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3B.Core.DTOs;
using Task3B.Core.ViewModels;

namespace Task3B.Service.Services.Service
{
    public interface IServiceService
    {
        List<ServiceViewModel> GetAll(int page);
        void Delete(int id);

        Task Create(CreateServiceDTO dto);
        void Update(UpdateServiceDTO dto);
    }
}
