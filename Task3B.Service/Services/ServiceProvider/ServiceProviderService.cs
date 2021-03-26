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

namespace Task3B.Service.Services.ServiceProvider
{
    public class ServiceProviderService : IServiceProviderService
    {
        private ApplicationDbContext _DB;
        public ServiceProviderService(ApplicationDbContext DB) {
            _DB = DB;
        }
        public void Create(CreateServiceProviderDTO dto)
        {
            var SP = new ServiceProviderDbEntity();
            SP.Name = dto.Name;
            SP.Phone = dto.Phone;
            SP.Email = dto.Email;
            _DB.ServiceProviders.Add(SP);
            _DB.SaveChanges();
        }
        public void Delete(int id)
        {
            var SP = _DB.ServiceProviders.SingleOrDefault(x => x.Id == id && !x.IsDeleted);
            if(SP != null){
                SP.IsDeleted = true;
                _DB.ServiceProviders.Update(SP);
                _DB.SaveChanges();
            }
        }

        public List<ServiceProviderViewModel> GetAll(int pageNum)
        {
            var ItemsPerPage = 5.0;
            var Pages = Math.Ceiling(_DB.ServiceProviders.Count() / ItemsPerPage);
            if (pageNum < 1 || pageNum > Pages)
                pageNum = 1;
            var skip = (int)((pageNum - 1) * ItemsPerPage);
            var SPs = _DB.ServiceProviders.Include(x => x.Services).Select(x => new ServiceProviderViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Phone = x.Phone,
                Email = x.Email,
                Services = x.Services.Select(s => new BaseServiceViewModel() {
                    Id = s.Id,
                    Description = s.Description,
                    Title = s.Title                    
                }).ToList()
            })
            .Skip(skip).ToList();
            return SPs;
        }

        public void Update(UpdateServiceProviderDTO dto)
        {
            var SP = _DB.ServiceProviders.SingleOrDefault(x => x.Id == dto.Id && !x.IsDeleted);
            SP.Name = dto.Name;
            SP.Phone = dto.Phone;
            SP.Email = dto.Email;
            _DB.ServiceProviders.Update(SP);
            _DB.SaveChanges();
        }
    }
}
