using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dependency_injection_sample.Dtos
{
    public class GetUserDto
    {
        public int id {get;set;}
        public string? name {get;set;}
        public int roleId {get;set;}
    }
}