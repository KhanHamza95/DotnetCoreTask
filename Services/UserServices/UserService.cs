using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dependency_injection_sample.Models;
using Dependency_injection_sample.Dtos;
using AutoMapper;
using Dependency_injection_sample.Data;
using Microsoft.EntityFrameworkCore;

namespace Dependency_injection_sample.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UserService(IMapper mapper, DataContext datacontext)
        {
            _mapper = mapper;
            _context = datacontext;
        }
        public async Task<ServiceResponse<List<GetUserDto>>> GetAllUsers(){
            ServiceResponse<List<GetUserDto>> serviceResponse = new ServiceResponse<List<GetUserDto>>();
            var dbUsers = await _context.Users.ToListAsync();
            try{
                serviceResponse.data = dbUsers.Select(user => _mapper.Map<GetUserDto>(user)).ToList();
                return serviceResponse;
            }
            catch(Exception e){
                serviceResponse.Message = e.ToString();
                serviceResponse.Success = false;
                return serviceResponse;
            }
        }
        public async Task<ServiceResponse<GetUserDto>> GetUserById(int id){
            ServiceResponse<GetUserDto> serviceResponse = new ServiceResponse<GetUserDto>();
            var dbUsers = await _context.Users.ToListAsync();
            try{
                serviceResponse.data = _mapper.Map<GetUserDto>(dbUsers.FirstOrDefault(user => user.id == id));
                if(serviceResponse.data != null){return serviceResponse;}
                else {
                    serviceResponse.Message = "No user exists against this user";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }
            }
            catch(Exception e){
                serviceResponse.Message = e.ToString();
                serviceResponse.Success = false;
                return serviceResponse;
            }
        }
        public async Task<ServiceResponse<GetUserDto>> AddUser(AddUserDto user){
            ServiceResponse<GetUserDto> serviceResponse = new ServiceResponse<GetUserDto>();
            try{
                User temp_user = _mapper.Map<User>(user);
                await _context.Users.AddAsync(temp_user);
                await _context.SaveChangesAsync();
                serviceResponse.data = _mapper.Map<GetUserDto>(temp_user);
                return serviceResponse;
            }
            catch(Exception e){
                serviceResponse.Message = e.ToString();
                serviceResponse.Success = false;
                return serviceResponse;
            }
        }
        public async Task<ServiceResponse<GetUserDto>> UpdateUser(UpdateUserDto user){
            ServiceResponse<GetUserDto> serviceResponse = new ServiceResponse<GetUserDto>();
            try{

                User temp_user = _mapper.Map<User>(user);
                _context.Users.Update(temp_user);
                await _context.SaveChangesAsync();
                serviceResponse.data= _mapper.Map<GetUserDto>(user);
                return serviceResponse;
            }
            catch(Exception e){
                serviceResponse.Message = e.ToString();
                serviceResponse.Success = false;
                return serviceResponse;
            }
        }
        public async Task<ServiceResponse<GetUserDto>> DeleteUser(User user){
            ServiceResponse<GetUserDto> serviceResponse = new ServiceResponse<GetUserDto>();
            try{
                _context.Remove(_context.Users.Single<User>(u => u.id == user.id && u.name == user.name && u.password == user.password));
                await _context.SaveChangesAsync();
                serviceResponse.data= _mapper.Map<GetUserDto>(user);
                serviceResponse.Message= "deleted";
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