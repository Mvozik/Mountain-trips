
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WycieczkiGórskie.Shared.Entities;

namespace WycieczkiGórskie.Shared.Services.IServices
{
    public interface IUserService
    {
        IEnumerable<Claim> GetClaims();
        Task<User> GetCurrentUserAsync();
      
    }
}
