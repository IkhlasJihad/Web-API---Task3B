using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task3B.Core.DTOs;
using Task3B.Service.Services.CustomerService;

namespace Task3B.API.Controllers
{
    public class CustomerServiceController : BaseController
    {
        private ICustomerServiceService _CSService;
        public CustomerServiceController(ICustomerServiceService CSService) {
            _CSService = CSService;
        }
        [HttpGet]
        public IActionResult GetAll(int pageNum) {
            return Ok(GetResponse("Done", _CSService.GetAll(pageNum)));
        }
        [HttpPost]
        public IActionResult Create([FromBody]CreateCustomerServiceDTO dto)
        {
            _CSService.Create(dto);
            return Ok(GetResponse("Added"));
        }
        [HttpPut]
        public IActionResult Update([FromBody] UpdateCustomerServiceDTO dto)
        {
            _CSService.Update(dto);
            return Ok(GetResponse("Updated"));
        }
        [HttpDelete]
        public IActionResult Delete([FromBody] DeleteCustomerServiceDTO dto)
        {
            _CSService.Delete(dto);
            return Ok(GetResponse("Deleted"));
        }
    }
}