using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3B.Core.DTOs;
using Task3B.Core.ViewModels;
using Task3B.Data;
using Task3B.Data.Models;

namespace Task3B.Service.Services.Customer
{
    public class CustomerService : ICustomerService
    {
        private ApplicationDbContext _DB;
        public CustomerService(ApplicationDbContext DB) {
            _DB = DB;
        }

        public List<CustomerViewModel> GetAll(int pageNum) {
            var ItemsPerPage = 5.0;
            var Pages = Math.Ceiling(_DB.Customers.Count() / ItemsPerPage);
            if (pageNum < 1 || pageNum > Pages)
                pageNum = 1;
            var skip = (int)((pageNum - 1) * ItemsPerPage);
            var Customers = _DB.Customers.Include(x => x.CustomerServices).ThenInclude(x => x.Service)
                .Select( c => new CustomerViewModel() { 
                    Email = c.Email,
                    Name = c.Name,
                    Id = c.Id,
                    Phone = c.Phone/*,
                    Services = c.CustomerServices.Select( cv => new BaseServiceViewModel()
                    {
                        Id = cv.ServiceId,
                        Title = cv.Service.Title,
                        Description = cv.Service.Description                                           
                    }
                    ).ToList()*/
                }).Skip(skip).ToList();
            return Customers;
        }

        public bool Delete(int id) {
            var Customer = _DB.Customers.SingleOrDefault(x => x.Id == id && !x.IsDeleted);
            if (Customer != null) {
                Customer.IsDeleted = true;
                _DB.Customers.Update(Customer);
                _DB.SaveChanges();
                return true;
            }
            return false;
        }

        public void Create(CreateCustomerDTO dto) {
            CustomerDbEntity Customer = new CustomerDbEntity();
            Customer.Name = dto.Name;
            Customer.Email = dto.Email;
            Customer.Phone = dto.Phone;
            _DB.Customers.Add(Customer);
            _DB.SaveChanges();
        }
        public void Update(UpdateCustomerDTO dto) {
            var Customer = _DB.Customers.SingleOrDefault(x => x.Id == dto.Id && !x.IsDeleted);
            if (Customer != null) {
                Customer.Name = dto.Name;
                Customer.Email = dto.Email;
                Customer.Phone = dto.Phone;
                Customer.UpdatedAt = DateTime.Now;
                _DB.Customers.Update(Customer);
                _DB.SaveChanges();
            }
        }
    }
}
