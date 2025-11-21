using efcore_navigation.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace efcore_navigation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {

        [HttpGet]
        [Route("users")]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

        [HttpGet]
        [Route("users/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok();
        }

        [HttpPost]
        [Route("users")]
        public async Task<IActionResult> Post(CreateUserRequest user)
        {
            return Created("/api/Users", "User Created Successfully");
        }


    }
}
