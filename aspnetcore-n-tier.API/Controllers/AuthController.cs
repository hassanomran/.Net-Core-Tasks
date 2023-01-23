using aspnetcore_n_tier.BLL.Services.IServices;
using aspnetcore_n_tier.DTO.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using System;

namespace aspnetcore_n_tier.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }
        [AllowAnonymous]
        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login(UserDTO input)
        {
            input.Username = input.Username.ToLower();
            var authUser = await _userService.LogIn(input);
            if (authUser == null)
            {
                return Unauthorized();
            }
            var claims = new[] {
                new Claim (ClaimTypes.Name, authUser.Username)
            };
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);


            return Ok(new
            {
                token = tokenHandler.WriteToken(token),
                authUser

            });

        }

    }
}
