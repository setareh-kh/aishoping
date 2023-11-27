using Aishopping.DTos.Requests;
using Aishopping.Models;
using Aishopping.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var users = await _userRepository.GetUsersAsync();
            return Ok(users == null ? "No Any User" : users);
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetUserAsync(int id)
        {
            var user = await _userRepository.GetUserAsync(id);
            return Ok(user == null ? "no user with this Id" : user);
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateAsync([FromBody] AddUser addUser)
        {
            var result = await _userRepository.CreateUserAsync(addUser);
            return Ok("You are successfully registered");
        }
        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateUser updateUser)
        {
            bool result = await _userRepository.UpdateUserAsync(id, updateUser);
            return Ok(result ? "Your profile has been updated" : "no user with this Id");
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            bool isDeleted = await _userRepository.DeleteUserAsync(id);
            return Ok(isDeleted ? "The user was deleted" : "no user with this Id");
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginUser loginUser)
        {
            bool logining= await _userRepository.LoginAsync(loginUser);
            return Ok(logining ? "Welecome" : "Wrong enter your Name Or your password");

        }

    }
}