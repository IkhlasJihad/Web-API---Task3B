using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task3B.Core.DTOs;
using Task3B.Service.Services.Customer;

namespace Task3B.API.Controllers
{
    public class CustomerController :BaseController
    {
        private ICustomerService _CustomerService;
        public CustomerController(ICustomerService service)
        {
            _CustomerService = service;
        }
        [HttpGet]
        public IActionResult GetAll(int pageNum)
        {
            var result = _CustomerService.GetAll(pageNum);
            return Ok(GetResponse("Done", result));
        }
        [HttpDelete]
        public IActionResult Delete(int id) {
            if(_CustomerService.Delete(id))
                return Ok(GetResponse("Deleted Successfully"));
            else
                return Ok(GetResponse("No Such record found"));
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateCustomerDTO dto){
            _CustomerService.Create(dto);
            return Ok(GetResponse("Added"));
        }
        [HttpPut]
        public IActionResult Update([FromBody] UpdateCustomerDTO dto)
        {
            _CustomerService.Update(dto);
            return Ok(GetResponse("Updated"));
        }
    }
}