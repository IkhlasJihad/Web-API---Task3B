using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3B.Core.DTOs;
using Task3B.Core.ViewModels;

namespace Task3B.Service.Services.ServiceProvider
{
    public interface IServiceProviderService
    {
        List<ServiceProviderViewModel> GetAll(int pageNum);
        void Delete(int id);

        void Create(CreateServiceProviderDTO dto);
        void Update(UpdateServiceProviderDTO dto);
    }
}
