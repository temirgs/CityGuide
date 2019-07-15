using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mycity.Helpers
{
    public static class JwtExtension
    {
        public static void AddApplicationError(this HttpResponse response,string message)
        {
            response.Headers.Add("Apllication-Error",message);
            response.Headers.Add("Access-Control-Allow-Origen","*");
            response.Headers.Add("Access-Control-Expose-Header", "Application-Error");
        }
    }
}
