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

namespace Task3B.Service.Services.SubSection
{
    public class SubSectionService : ISubSectionService
    {
        private ApplicationDbContext _DB;
        public SubSectionService(ApplicationDbContext DB)
        {
            _DB = DB;
        }

        public void Create(CreateSubSectionDTO dto)
        {
            var Subsection = new SubSectionDbEntity();
            Subsection.Description = dto.Description;
            Subsection.Name = dto.Name;
            Subsection.SectionId = dto.SectionId;
            _DB.SubSections.Add(Subsection);
            _DB.SaveChanges();
        }

        public void Delete(int id)
        {
            var Subsection = _DB.SubSections.SingleOrDefault(x => id == x.Id && !x.IsDeleted);
            if (Subsection != null) {
                Subsection.IsDeleted = true;
                _DB.SubSections.Update(Subsection);
                _DB.SaveChanges();
            }
        }
        public List<SubSectionViewModel> GetAll(int pageNum)
        {
            var ItemsPerPage = 5.0;
            var Pages = Math.Ceiling(_DB.SubSections.Count() / ItemsPerPage);
            if (pageNum < 1 || pageNum > Pages)
                pageNum = 1;
            var skip = (int)((pageNum - 1) * ItemsPerPage);
            var Subsections = _DB.SubSections.Include(x => x.Section).Include(x => x.Services).Select(x => new SubSectionViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Section = new BaseSectionViewModel() {
                    Id = x.Section.Id,
                    Name = x.Section.Name,
                    CreatedAt = x.Section.CreatedAt
                },
                Services = x.Services.Select(s => new BaseServiceViewModel() { 
                    Id = s.Id,
                    Description = s.Description,
                    Title = s.Title
                }).ToList()
            }).Skip(skip).ToList();
            return Subsections;
        }
        public void Update(UpdateSubSectionDTO dto)
        {
            var Subsection = _DB.SubSections.SingleOrDefault(x => dto.Id == x.Id && !x.IsDeleted);
            if (Subsection != null)
            {
                Subsection.Name = dto.Name;
                Subsection.SectionId = dto.SectionId;
                Subsection.UpdatedAt = DateTime.Now;
                Subsection.Description = dto.Description;
                _DB.SubSections.Update(Subsection);
                _DB.SaveChanges();
            }
        }
    }
}
