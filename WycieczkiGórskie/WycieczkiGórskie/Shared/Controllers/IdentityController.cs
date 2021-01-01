
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using WycieczkiGórskie.Shared.Dtos;
using WycieczkiGórskie.Shared.Dtos.Responses;
using WycieczkiGórskie.Shared.Services.IServices;

namespace WycieczkiGórskie.Shared.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : Controller
    {
        private readonly IIdentityService _identityService;
        private readonly IUserService _userService;
        public IdentityController(IIdentityService identityService, IUserService userService)
        {
            _identityService = identityService;
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserPostRegistrationDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage))
                });
            }

            var authResponse = await _identityService.RegisterAsync(request);
            if (!authResponse.Success)
            {
                return BadRequest(new AuthFailedResponse { Errors = authResponse.Errors });
            }

            return Ok(new AuthSuccessResponse { Token = authResponse.Token, RefreshToken = authResponse.RefreshToken });
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserPostLoginDto request)
        {
            var authResponse = await _identityService.LoginAsync(request);
            if (!authResponse.Success)
            {
                return BadRequest(new AuthFailedResponse { Errors = authResponse.Errors });
            }

            return Ok(new AuthSuccessResponse { Token = authResponse.Token, RefreshToken = authResponse.RefreshToken });
        }

        [HttpPost("Refesh-Token")]
        public async Task<IActionResult> RefreshToken(RefreshTokenDto refreshTokenDto)
        {
            var response = await _identityService.RefreshTokenAsync(refreshTokenDto.Token, refreshTokenDto.RefreshToken);
            if(!response.Success)
            {
                return BadRequest(new AuthFailedResponse { Errors=response.Errors });
            }
            return Ok( new AuthSuccessResponse
            { 
                Token = response.Token,
                RefreshToken = response.RefreshToken
            });
        }


        [HttpPost("Logout")]
        public async Task<IActionResult> Logout(string refreshToken)
        {
            var response = await _identityService.LogoutAsync(refreshToken);
            if (!response.Success)
            {
                return BadRequest(new AuthFailedResponse { Errors = response.Errors });
            }
            return Ok();
        }

   

   

    }
}
