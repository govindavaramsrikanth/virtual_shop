namespace WebApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetUsers()
        {
            // This method will return a list of users
            return Ok(new[] { "Srikanth", "Virender", "Sandeep" });
        }

        [HttpGet("{username}")]
        public IActionResult Getuser(String username)
        {
            return Ok($"User : {username}");
        }
    }


}