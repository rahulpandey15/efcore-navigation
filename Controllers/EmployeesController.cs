using efcore_navigation.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace efcore_navigation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok();
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post(CreateUserRequest user)
        {
            return Created("/api/Users", "User Created Successfully");
        }


    }
}
