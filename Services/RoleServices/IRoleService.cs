using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dependency_injection_sample.Models;
using Dependency_injection_sample.Dtos;
namespace Dependency_injection_sample.Services.RoleServices
{
    public interface IRoleService
    {
        Task<ServiceResponse<List<Role>>> GetRoles();
        Task<ServiceResponse<Role>> AddRole(AddRoleDto role);
        Task<ServiceResponse<Role>> UpdateRole(Role role);
    }
}
