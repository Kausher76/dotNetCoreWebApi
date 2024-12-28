using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementApi.Entities;
using StudentManagementApi.Services;

namespace StudentManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsersService _usersService;
        public UserController(IUsersService usersService)
        {
            _usersService = usersService;
            
        }

        [HttpPost("getAllUsers")]
        public IActionResult getAllUsers()
        {
            string message = "";

            try
            {
                var users = _usersService.GetUsers();
                return Ok(users);

            }
            catch (Exception ex) 
            {
                message = ex.Message;
            }
            return BadRequest(message);
        }
        [HttpPost("createNewUser")]
        public IActionResult createNewUser(Users user) 
        {
            string message = "";
            try
            {
                message = _usersService.CreateUser(user);
            }
            catch(Exception ex)
            {
                message = ex.Message;

            }
            return Ok(message);
        }

        [HttpPost("deleteUser")]
        public IActionResult deleteUser(Users user)
        {
            string message = "";
            try
            {
                message = _usersService.DeleteUser(user);
            }
            catch (Exception ex)
            {
                message = ex.Message;

            }
            return Ok(message);
        }

        [HttpPost("UpdateUser")]
        public IActionResult UpdateUser(Users user)
        {
            string message = "";
            try
            {
                message = _usersService.UpdateUser(user);
            }
            catch (Exception ex)
            {
                message = ex.Message;

            }
            return Ok(message);
        }
    }
}
