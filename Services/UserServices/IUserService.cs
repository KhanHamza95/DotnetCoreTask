using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dependency_injection_sample.Models;
using Dependency_injection_sample.Dtos;
namespace Dependency_injection_sample.Services.UserServices
{
    public interface IUserService
    {
        Task<ServiceResponse<List<GetUserDto>>> GetAllUsers();
        Task<ServiceResponse<GetUserDto>> GetUserById(int id);
        Task<ServiceResponse<GetUserDto>>AddUser(AddUserDto user);
        Task<ServiceResponse<GetUserDto>> UpdateUser(UpdateUserDto user);
        Task<ServiceResponse<GetUserDto>> DeleteUser(User user);
    }
}