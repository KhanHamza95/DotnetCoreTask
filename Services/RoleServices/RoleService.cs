using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dependency_injection_sample.Models;
using Dependency_injection_sample.Data;
using Microsoft.EntityFrameworkCore;
using Dependency_injection_sample.Dtos;
using AutoMapper;
namespace Dependency_injection_sample.Services.RoleServices
{
    public class RoleService : IRoleService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper; 
        public RoleService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<Role>>> GetRoles(){
            ServiceResponse<List<Role>> serviceResponse = new ServiceResponse<List<Role>>();
            try{
                var dbRoles = await _context.Roles.ToListAsync();
                serviceResponse.data = dbRoles;
                return serviceResponse;
            }
            catch(Exception e){
                serviceResponse.Message = e.ToString();
                serviceResponse.Success = false;
                return serviceResponse;
            }
        }
        public async Task<ServiceResponse<Role>> AddRole(AddRoleDto role){
            ServiceResponse<Role> serviceResponse = new ServiceResponse<Role>();
            try{
                Role temp_role = _mapper.Map<Role>(role);
                await _context.Roles.AddAsync(temp_role);
                await _context.SaveChangesAsync();
                serviceResponse.data = temp_role;
                return serviceResponse;
            }
            catch(Exception e){
                serviceResponse.Message = e.ToString();
                serviceResponse.Success = false;
                return serviceResponse;
            }
        }
        public async Task<ServiceResponse<Role>> UpdateRole(Role role){
            ServiceResponse<Role> serviceResponse = new ServiceResponse<Role>();
            try{
                _context.Roles.Update(role);
                await _context.SaveChangesAsync();
                serviceResponse.data= role;
                return serviceResponse;
            }
            catch(Exception e){
                serviceResponse.Message = e.ToString();
                serviceResponse.Success = false;
                return serviceResponse;
            }
        }
    }
}