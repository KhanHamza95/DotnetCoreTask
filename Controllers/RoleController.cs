using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dependency_injection_sample.Services.RoleServices;
using Dependency_injection_sample.Models;
using Dependency_injection_sample.Dtos;

namespace Dependency_injection_sample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase{
        private readonly  IRoleService _roleservice;
        public RoleController(IRoleService iroleservice){
            _roleservice = iroleservice;
        }
        [HttpGet("GetAllRoles")]
        public async Task<ActionResult<ServiceResponse<List<Role>>>> GetAllRoles(){
            return Ok(await _roleservice.GetRoles());
        }
        [HttpPost("AddRole")]
        public async Task<ActionResult<ServiceResponse<Role>>> AddRole(AddRoleDto role){
            return Ok(await _roleservice.AddRole(role));
        }
        [HttpPut("UpdateRole")]
        public async Task<ActionResult<ServiceResponse<Role>>> UpdateRole(Role role){
            return Ok(await _roleservice.UpdateRole(role));
        }
    }
}