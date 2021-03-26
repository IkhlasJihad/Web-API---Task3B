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

namespace Task3B.Service.Services.CustomerService
{
    public class CustomerServiceService : ICustomerServiceService
    {
        private ApplicationDbContext _DB;
        public CustomerServiceService(ApplicationDbContext DB)
        {
            _DB = DB;
        }

        public void Create(CreateCustomerServiceDTO dto)
        {
            var CS = new CustomerServiceDbEntity();
            CS.CustomerId = dto.CustomerId;
            CS.ServiceId = dto.ServiceId;
            CS.Price = dto.Price;
            CS.OrderDate = dto.OrderDate;
            _DB.CustomerServices.Add(CS);
            _DB.SaveChanges();
        }

        public void Delete(DeleteCustomerServiceDTO dto)
        {
            var CS = _DB.CustomerServices.SingleOrDefault(x => x.CustomerId == dto.CustomerId 
                                                            && x.ServiceId == dto.ServiceId && !x.IsDeleted);
            if (CS != null) {
                CS.IsDeleted = true;
                _DB.CustomerServices.Update(CS);
                _DB.SaveChanges();
            }
        }
        public List<CustomerServiceViewModel> GetAll(int pageNum)
        {
            var ItemsPerPage = 5.0;
            var Pages = Math.Ceiling(_DB.CustomerServices.Count() / ItemsPerPage);
            if (pageNum < 1 || pageNum > Pages)
                pageNum = 1;
            var skip = (int)((pageNum - 1) * ItemsPerPage);
            var CSs = _DB.CustomerServices.Include(x => x.Service).Include(x => x.Customer).Select(x => new CustomerServiceViewModel()
            {
                Price = x.Price,
                OrderDate = x.OrderDate,
                Customer = new CustomerViewModel() { 
                    Id = x.CustomerId,
                    Name = x.Customer.Name,
                    Email = x.Customer.Email,
                    Phone = x.Customer.Phone
                },
                Service = new BaseServiceViewModel() { 
                    Id = x.Service.Id,
                    Title = x.Service.Title,
                    Description = x.Service.Description
                }
            }).Skip(skip).ToList();
            return CSs;
        }
        public void Update(UpdateCustomerServiceDTO dto)
        {
            var CS = _DB.CustomerServices.SingleOrDefault(x => x.CustomerId == dto.CustomerId 
                                                            && x.ServiceId == dto.ServiceId  && !x.IsDeleted);
            if (CS != null)
            {
                CS.UpdatedAt = DateTime.Now;
                CS.Price = dto.Price;
                CS.OrderDate = dto.OrderDate;
                _DB.CustomerServices.Update(CS);
                _DB.SaveChanges();
            }
        }
    }
}
