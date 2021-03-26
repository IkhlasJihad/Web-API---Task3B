using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3B.Core.DTOs;
using Task3B.Core.ViewModels;

namespace Task3B.Service.Services.CustomerService
{
    public interface ICustomerServiceService
    {
        List<CustomerServiceViewModel> GetAll(int pageNum);
        void Delete(DeleteCustomerServiceDTO dto);

        void Create(CreateCustomerServiceDTO dto);
        void Update(UpdateCustomerServiceDTO dto);
    }
}
