using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GranadaShopClase.API.Identity.Controllers;

[ApiVersion(1)]

[ApiController]
[Route("api/v{v:apiVersion}/[controller]")]

    public class AuthController : ControllerBase
    {
        private IEnumerable<User> _users = new List<User>();
   
    [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            if (_users.Any(u => u.Username == user.Username))
            {
                return BadRequest("Username already exists.");
            }
            user.Id = _users.Count() + 1;
            _users = _users.Append(user);
            return Ok("User registered successfully.");
        }

   

    [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            var existingUser = _users.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
            if (existingUser == null)
            {
                return Unauthorized("Invalid username or password.");
            }
            return Ok("Login successful.");
        }
    }
    public class User
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
    }

