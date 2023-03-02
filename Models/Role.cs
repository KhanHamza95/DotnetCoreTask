using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dependency_injection_sample.Models
{
    public class Role
    {
        public int roleId {get;set;}
        public string roleName {get;set;} = string.Empty;
        public Boolean read {get;set;} = false;
        public Boolean write {get;set;} = false;
        public Boolean delete {get;set;} = false;
        public List<User> users = new List<User>();
    }
}