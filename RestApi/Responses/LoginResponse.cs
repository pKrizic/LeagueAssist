using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace RestApi.Responses
{
    public class LoginResponse
    {
        public string result { get; set; }
        public string id { get; set; }
        public string errorMessage { get; set; }
    }
}