using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task3B.Core.DTOs;
using Task3B.Service.Services.Service;

namespace Task3B.API.Controllers
{
    public class ServiceController : BaseController
    {
        private IServiceService _ServiceService;
        public ServiceController(IServiceService Service) {
            _ServiceService = Service;
        }
        [HttpGet]
        public IActionResult GetAll(int pageNum)
        {
            var result = _ServiceService.GetAll(pageNum);
            return Ok(GetResponse("Done", result));
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateServiceDTO dto)
        {
            await _ServiceService.Create(dto);
            return Ok(GetResponse("Added"));
        }
        [HttpPut]
        public IActionResult Update([FromBody] UpdateServiceDTO dto)
        {
            _ServiceService.Update(dto);
            return Ok(GetResponse("Updated"));
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _ServiceService.Delete(id);
            return Ok(GetResponse("Deleted Successfully"));
        }
    }
}
