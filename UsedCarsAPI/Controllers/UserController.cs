using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsedCarsAPI.Models;
using UsedCarsAPI.Repositories;
using UsedCarsAPI.Repositories.Interfaces;

namespace UsedCarsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> FindAllUsers()
        {
            List<UserModel> users = await _userRepository.FindAllUsers();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> FindUserById(int id)
        {
            UserModel user = await _userRepository.FindUserById(id);
            return Ok(user);
        }
    }
}
