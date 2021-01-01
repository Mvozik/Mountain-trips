using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WycieczkiGórskie.Shared.Dtos.Responses
{
    public class AuthSuccessResponse
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
