using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketingSystem.BLL.Contracts;
using TicketingSystem.BLL.Services;
using TicketingSystem.ViewModel.ViewModel;
using TicketingSystem.ViewModel.ViewModels;

namespace Ticketing_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService<UserVM, LoginVM, string> userService;

        public UserController(UserService _userService)
        {
            userService = _userService;
        }

        [HttpPost("[action]")]
        [Authorize(Roles = "Admin")]
        [AllowAnonymous]
        public async Task<ActionResult<ResponseVM>> Register([FromBody] UserVM userVM)
        {
            if (ModelState.IsValid)
            {
                var res = await userService.Register(userVM);
                return Ok(res);
            }
            else
                return BadRequest("Something went wrong");
        }


        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<ActionResult<ResponseVM>> Login([FromBody] LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                var res = await userService.Login(loginVM);
                if (res.IsSuccess)
                    return Ok(res);
                else
                    return BadRequest(res);
            }
            else
                return BadRequest("Something went wrong");
        }

        [HttpGet("[action]")]
        public async Task<UserVM> UserProfile()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            return await userService.UserProfile(userId);
        }

        [HttpGet("[action]")]
        [Authorize(Roles = "Admin")]
        public string ForAdmin()
        {
            return "For Admin";
        }

        [HttpGet("[action]")]
        [Authorize(Roles = "IT Staff")]
        public string ForITStaff()
        {
            return "For IT Staff";
        }


        [HttpGet("[action]")]
        [Authorize(Roles = "Admin,IT Staff")]
        public string ForAdminOrITStaff()
        {
            return "For Admin or IT Staff";
        }

        [HttpGet("[action]/{userName}")]
        [AllowAnonymous]
        public async Task<ActionResult<ForgotPasswordVM>> GetSecurityQuestion(string userName)
        {
            if (ModelState.IsValid)
            {
                var res = await userService.GetSecurityQuestion(userName);
                if (res != null)
                    return Ok(res);
                else
                    return NotFound(res);
            }
            else
                return BadRequest("Something went wrong");
        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<ActionResult<ResponseVM>> ResetPassword([FromBody]ForgotPasswordVM forgotPasswordVM)
        {
            if (ModelState.IsValid)
            {
                var res = await userService.ResetPassword(forgotPasswordVM);
                if (res.IsSuccess)
                    return Ok(res);
                else
                    return BadRequest(res);
            }
            else
                return BadRequest("Something went wrong");
        }
        [HttpGet("[action]")]
        public IEnumerable<UserVM> GetAll()
        {
            return userService.GetAll();
        }

        [HttpDelete("[action]/{id}")]
        public Task<ResponseVM> Delete
            (string id)
        {
            return userService.Delete(id);
        }
    }
}
