using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task3B.Core.DTOs;
using Task3B.Core.ViewModels;
using Task3B.Service.Services.User;

namespace Task3B.API.Controllers
{
    public class UserController : BaseController
    {
        private IUserService _UserService;

        public UserController(IUserService UserService) {
            _UserService = UserService;
        }
        [HttpGet]
        public IActionResult GetAll(int pageNum) {
            var result =  _UserService.GetAll(pageNum);
            return Ok(GetResponse("Done", result));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserDTO dto) {
            await _UserService.Create(dto);
            return Ok(GetResponse("Added"));
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserDTO dto)
        {
            await _UserService.Update(dto);
            return Ok(GetResponse("Updated"));
        }
        [HttpDelete]
        public IActionResult Delete(String id) {
            _UserService.Delete(id);
            return Ok(GetResponse("Deleted"));
        }

    }
}
