using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3B.Core.DTOs;
using Task3B.Core.ViewModels;
using Task3B.Data;
using Task3B.Data.Models;

namespace Task3B.Service.Services.User
{
    public class UserService : IUserService
    {
        private ApplicationDbContext _DB;
        private UserManager<UserDbEntity> _UserManager;

        public UserService(ApplicationDbContext DB, UserManager<UserDbEntity> UserManager) {
            _DB = DB;
            _UserManager = UserManager;
        }

        public List<UserViewModel> GetAll(int pageNum) {
            var ItemsPerPage = 5.0;
            var Pages = Math.Ceiling(_DB.Users.Where(x => !x.isDeleted).Count() / ItemsPerPage);
            if (pageNum < 1 || pageNum > Pages)
                pageNum = 1;
            var skip = (int)((pageNum - 1) * ItemsPerPage);
            var Users = _DB.Users.Where(x => !x.isDeleted).Select(x => new UserViewModel()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Phone = x.PhoneNumber,
                DOB = x.DOB
            }).Skip(skip).ToList();
            return Users;
        }
        public async Task<bool> Create(CreateUserDTO dto) {
            var User = new UserDbEntity();
            User.DOB = dto.DOB;
            User.Email = dto.Email;
            User.PhoneNumber = dto.Phone;
            User.LastName = dto.LastName;
            User.FirstName = dto.FirstName;
            User.CreatedAt = DateTime.Now;
            User.UserName = dto.Phone;
            var result = await _UserManager.CreateAsync(User, Guid.NewGuid().ToString());
            return result.Succeeded;
        }
        
        public async Task Update(UpdateUserDTO dto) {
            var User = _DB.Users.SingleOrDefault(x => !x.isDeleted && x.Id == dto.Id);
            if (User != null)
            {
                User.FirstName = dto.FirstName;
                User.LastName = dto.LastName;
                User.DOB = dto.DOB;
                User.Email = dto.Email;
                User.UpdatedAt = DateTime.Now;
                await _UserManager.UpdateAsync(User);
            }
        }
        public void Delete(string id)
        {
            var User = _DB.Users.SingleOrDefault(x => !x.isDeleted && x.Id == id);
            if (User != null)
            {
                User.isDeleted = true;
                _DB.Users.Update(User);
                _DB.SaveChanges();
            }
        }

    }
}
