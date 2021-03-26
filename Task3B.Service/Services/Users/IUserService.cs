using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3B.Core.DTOs;
using Task3B.Core.ViewModels;

namespace Task3B.Service.Services.User
{
    public interface IUserService
    {
        List<UserViewModel> GetAll(int pageNum);
        Task<bool> Create(CreateUserDTO dto);
        Task Update(UpdateUserDTO dto);

        void Delete(string id);
    }
}
