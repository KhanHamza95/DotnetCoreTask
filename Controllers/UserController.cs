using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dependency_injection_sample.Models;
using Dependency_injection_sample.Services.UserServices;
using Dependency_injection_sample.Dtos;
namespace Dependency_injection_sample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetUserDto>>>> GetAllUsers(){
            return Ok(await _userService.GetAllUsers());
        }
        [HttpGet("GetById")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> GetUserById(int id){
            return Ok(await _userService.GetUserById(id));
        }
        [HttpPost("AddUser")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> AddUser(AddUserDto user){
            return Ok(await _userService.AddUser(user));
        }
        [HttpPut("UpdateUser")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> UpdateUser(UpdateUserDto user){
            return Ok(await _userService.UpdateUser(user));
        }
        [HttpDelete("DeleteUser")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> DeleteUser(User user){
            return Ok(await _userService.DeleteUser(user));
        }
    }
}