using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dependency_injection_sample.Models
{
    public class ServiceResponse<T>
    {
        public T? data {get;set;}
        public Boolean Success {get;set;} = true;
        public string Message{get;set;} = string.Empty;
    }
}