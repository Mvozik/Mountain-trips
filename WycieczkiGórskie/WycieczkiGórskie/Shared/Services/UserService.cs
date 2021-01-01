
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WycieczkiGórskie.Shared.Entities;
using WycieczkiGórskie.Shared.Services.IServices;

namespace WycieczkiGórskie.Shared.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

 

        public IEnumerable<Claim> GetClaims()
        {
            var claims = _httpContextAccessor.HttpContext?.User?.Claims;

            if (claims == null)
                return Enumerable.Empty<Claim>();

            return claims;
        }

        public async Task<User> GetCurrentUserAsync()
        {
            var userClaims = GetClaims().ToList();

            if (userClaims.Any())
            {
                var name = userClaims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
                return await _userManager.FindByNameAsync(name);
            }

            return null;
        }
      
  
    }
}
