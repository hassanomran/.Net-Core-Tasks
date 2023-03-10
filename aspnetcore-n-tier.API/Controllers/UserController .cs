using aspnetcore_n_tier.BLL.CustomExceptions;
using aspnetcore_n_tier.BLL.Services.IServices;
using aspnetcore_n_tier.DTO.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace aspnetcore_n_tier.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getusers")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _userService.GetAllUser();
                return Ok(users);
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong");
            }
        }

        [HttpGet("getuser")]
        public async Task<IActionResult> GetUser(int userId)
        {
            try
            {
                return Ok(await _userService.GetUser(userId));
            }
            catch (UserNotFoundException)
            {
                return NotFound("User not found");
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong");
            }
        }

        [HttpPost("adduser")]
        public async Task<IActionResult> AddUser(UserToAddDTO userToAddDTO)
        {
            try
            {
                return Ok(await _userService.AddUser(userToAddDTO));
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong");
            }
        }

        [HttpPut("updateuser")]
        public async Task<IActionResult> UpdateUser(UsertDetailsUpdateDTO userToUpdateDTO)
        {
            try
            {
                return Ok(await _userService.UpdateUser(userToUpdateDTO));
            }
            catch (UserNotFoundException)
            {
                return NotFound("User not found");
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong");
            }
        }

        [HttpDelete("deleteuser")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            try
            {
                await _userService.DeleteUser(userId);
                return Ok();
            }
            catch (UserNotFoundException)
            {
                return NotFound("User not found");
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong");
            }
        }
    }
}