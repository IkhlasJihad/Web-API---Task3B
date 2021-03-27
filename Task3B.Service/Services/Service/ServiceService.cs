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
using Task3B.Service.Services.File;

namespace Task3B.Service.Services.Service
{
    public class ServiceService : IServiceService
    {
        private ApplicationDbContext _DB;
        private IFileService _fileService;
        public ServiceService(ApplicationDbContext DB, IFileService fileService) {
            _DB = DB;
            _fileService = fileService;
        }
        public async Task Create(CreateServiceDTO dto)
        {
            try {
                var CreatedService = new ServiceDbEntity();
                CreatedService.Title = dto.Title;
                CreatedService.Description = dto.Description;
                CreatedService.SubSectionId = dto.SubSectionId;
                CreatedService.ServiceProviderId = dto.ServiceProviderId;
                _DB.Services.Add(CreatedService);
                _DB.SaveChanges();
                foreach (var file in dto.Files)
                {
                    var fileName = await _fileService.SaveFile(file, "Files");
                    var fileEntity = new FileDbEntity();
                    fileEntity.ServiceId = CreatedService.Id;
                    fileEntity.FilePath = fileName;
                    _DB.Files.Add(fileEntity);                    
                }
                _DB.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public List<ServiceViewModel> GetAll(int pageNum)
        {
            var ItemsPerPage = 5.0;
            var Pages = Math.Ceiling(_DB.Services.Count() / ItemsPerPage);
            if (pageNum < 1 || pageNum > Pages)
                pageNum = 1;
            var skip = (int)((pageNum - 1) * ItemsPerPage);
            var Services = _DB.Services.Include(x => x.ServiceProvider).Include(x => x.Files).Include(x => x.SubSection).
            Select(x => new ServiceViewModel() {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Provider = new BaseServiceProviderViewModel() { 
                    Id = x.ServiceProvider.Id,
                    Name = x.ServiceProvider.Name,
                    Email = x.ServiceProvider.Email,
                    Phone = x.ServiceProvider.Phone
                },
                SubSection = new BaseSubSectionViewModel() { 
                    Id = x.SubSection.Id,
                    Name = x.SubSection.Name,
                    Description = x.SubSection.Description                       
                },
                Files = x.Files.Select(f => f.FilePath).ToList()
            }).Skip(skip).ToList();
            return Services;
        }

        public void Update(UpdateServiceDTO dto)
        {
            var Service = _DB.Services.SingleOrDefault(x => x.Id == dto.Id && !x.IsDeleted);
            if (Service != null)
            {
                Service.Title = dto.Title;
                Service.Description = dto.Description;
                Service.UpdatedAt = DateTime.Now;
                Service.ServiceProviderId = dto.ServiceProviderId;
                Service.SubSectionId = dto.SubSectionId;
                _DB.Services.Update(Service);
                _DB.SaveChanges();
            }
        }        public void Delete(int id)
        {
            var Service = _DB.Services.SingleOrDefault(x => x.Id == id && !x.IsDeleted);
            if (Service != null)
            {
                Service.IsDeleted = true;
                _DB.Services.Update(Service);
                _DB.SaveChanges();
            }
        }

    }
}
