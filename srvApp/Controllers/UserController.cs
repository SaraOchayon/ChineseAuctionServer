using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace srvApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        static List<User> users;
         

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] User user)
        {
            users.Add(user);
        }

     
    }
}
