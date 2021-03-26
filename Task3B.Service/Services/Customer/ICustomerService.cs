using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Task3B.Core.ViewModels;
using Task3B.Core.DTOs;

namespace Task3B.Service.Services.Customer
{
    public interface ICustomerService
    {
        List<CustomerViewModel> GetAll(int pageNum);
        bool Delete(int id);

        void Create(CreateCustomerDTO dto);
        void Update(UpdateCustomerDTO dto);
    }
}
