using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task3B.Core.DTOs;
using Task3B.Service.Services.ServiceProvider;

namespace Task3B.API.Controllers
{
    public class ServiceProviderController : BaseController
    {
        private IServiceProviderService _SPService;

        public ServiceProviderController(IServiceProviderService Service) {
            _SPService = Service;
        }
        [HttpGet]
        public IActionResult GetAll(int pageNum)
        {
            var result = _SPService.GetAll(pageNum);
            return Ok(GetResponse("Done", result));
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _SPService.Delete(id);
            return Ok(GetResponse("Deleted Successfully"));
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateServiceProviderDTO dto)
        {
            _SPService.Create(dto);
            return Ok(GetResponse("Added"));
        }
        [HttpPut]
        public IActionResult Update([FromBody] UpdateServiceProviderDTO dto)
        {
            _SPService.Update(dto);
            return Ok(GetResponse("Updated"));
        }
    }
}
