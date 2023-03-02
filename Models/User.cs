using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dependency_injection_sample.Models
{
    public class User
    {
        public int id {get;set;}
        public string? name {get;set;}
        public string password {get;set;} = string.Empty;
        public int roleId {get;set;}
    }
}