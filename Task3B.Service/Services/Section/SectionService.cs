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

namespace Task3B.Service.Services.Section
{
    public class SectionService : ISectionService
    {
        private ApplicationDbContext _DB;
        public SectionService(ApplicationDbContext DB)
        {
            _DB = DB;
        }
        public void Create(CreateSectionDTO dto)
        {
            var Section = new SectionDbEntity();
            Section.Description = dto.Description;
            Section.Name = dto.Name;
            _DB.Sections.Add(Section);
            _DB.SaveChanges();
        }

        public void Delete(int id)
        {
            var Section = _DB.Sections.SingleOrDefault(x => x.Id == id && !x.IsDeleted);
            if (Section != null) { 
                Section.IsDeleted = true;
                _DB.Sections.Update(Section);
                _DB.SaveChanges();
            }
        }

        public List<SectionViewModel> GetAll(int pageNum)
        {
            var ItemsPerPage = 5.0;
            var Pages = Math.Ceiling(_DB.Sections.Count() / ItemsPerPage);
            if (pageNum < 1 || pageNum > Pages)
                pageNum = 1;
            var skip = (int)((pageNum - 1) * ItemsPerPage);
            var Sections = _DB.Sections.Include(x => x.SubSections).Select(x => new SectionViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                CreatedAt = x.CreatedAt,
                SubSections = x.SubSections.Select( s => new BaseSubSectionViewModel() { 
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description
                }).ToList()
            }).Skip(skip).ToList();
            return Sections;
        }

        public void Update(UpdateSectionDTO dto)
        {
            var Section = _DB.Sections.SingleOrDefault(x => x.Id == dto.Id && !x.IsDeleted);
            if (Section != null)
            {
                Section.Name = dto.Name;
                Section.UpdatedAt = DateTime.Now;
                Section.Description = dto.Description;
                _DB.Sections.Update(Section);
                _DB.SaveChanges();
            }
        }
    }
}
