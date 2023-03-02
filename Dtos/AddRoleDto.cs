using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dependency_injection_sample.Dtos
{
    public class AddRoleDto
    {
        public string roleName {get;set;} = string.Empty;
        public Boolean read {get;set;} = false;
        public Boolean write {get;set;} = false;
        public Boolean delete {get;set;} = false;
    }
}