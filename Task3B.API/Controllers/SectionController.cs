using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task3B.Core.DTOs;
using Task3B.Service.Services.Section;

namespace Task3B.API.Controllers
{
    public class SectionController : BaseController
    {
        private ISectionService _SectionService;
        public SectionController(ISectionService SectionService) {
            _SectionService = SectionService;
        }
        [HttpGet]
        public IActionResult GetAll(int pageNum)
        {
            var result = _SectionService.GetAll(pageNum);
            return Ok(GetResponse("Done", result));
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _SectionService.Delete(id);
                return Ok(GetResponse("Deleted Successfully"));
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateSectionDTO dto)
        {
            _SectionService.Create(dto);
            return Ok(GetResponse("Added"));
        }
        [HttpPut]
        public IActionResult Update([FromBody] UpdateSectionDTO dto)
        {
            _SectionService.Update(dto);
            return Ok(GetResponse("Updated"));
        }

    }
}
