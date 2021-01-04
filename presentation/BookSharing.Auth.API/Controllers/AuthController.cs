using Microsoft.AspNetCore.Mvc;

namespace BookSharing.Auth.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        // GET: api/login/
        [HttpGet("login")]
        public ActionResult Login()
        {
            return Ok("ok");
        }
    }
}
