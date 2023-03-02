using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dependency_injection_sample.Dtos
{
    public class UpdateUserDto
    {
        public int id {get;set;}
        public string? name {get;set;}
        public string password {get;set;} = string.Empty;
        public int roleId {get;set;}
    }
}