using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task3B.Core.DTOs;
using Task3B.Service.Services.SubSection;

namespace Task3B.API.Controllers
{
    public class SubSectionController : BaseController
    {
        private ISubSectionService _SubsectionService;
        public SubSectionController(ISubSectionService Service) {
            _SubsectionService = Service;
        }
        [HttpGet]
        public IActionResult GetAll(int pageNum)
        {
            var result = _SubsectionService.GetAll(pageNum);
            return Ok(GetResponse("Done", result));
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _SubsectionService.Delete(id);
            return Ok(GetResponse("Deleted Successfully"));
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateSubSectionDTO dto)
        {
            _SubsectionService.Create(dto);
            return Ok(GetResponse("Added"));
        }
        [HttpPut]
        public IActionResult Update([FromBody] UpdateSubSectionDTO dto)
        {
            _SubsectionService.Update(dto);
            return Ok(GetResponse("Updated"));
        }
    }
}
