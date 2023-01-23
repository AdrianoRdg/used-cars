using Microsoft.AspNetCore.Mvc;
using UsedCarsAPI.Data;
using UsedCarsAPI.Models;
using UsedCarsAPI.Services;

namespace UsedCarsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UsedCarsDBContext _dbContext;

        public AuthController(UsedCarsDBContext usedCarsDBContext)
        {
            _dbContext = usedCarsDBContext;
        }
        [HttpPost]
        public async Task<IActionResult> Auth([FromBody] UserModel user)
        {
            var TokenService = new TokenService(_dbContext);
            var token = await TokenService.GenerateToken(user.Email, user.Password);

            if (token == null)
            {
                throw new Exception("Incorrect Email or password");
            }

            return Ok(token);
        }
    }
}
