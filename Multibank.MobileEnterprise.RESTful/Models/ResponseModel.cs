using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Multibank.MobileEnterprise.RESTful.Models
{
    public class ResponseModel<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; } = false;
        public string Error { get; set; }
    }
}