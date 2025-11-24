using efcore_navigation.Data;
using efcore_navigation.RequestModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace efcore_navigation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly SampledbContext sampledbContext;

        public DepartmentController(SampledbContext sampledbContext)
        {
            this.sampledbContext = sampledbContext;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            var department = await sampledbContext.Departments.ToListAsync(); // SELECT * FROM DEPARTMENTS


            return Ok(department);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            var departments = await sampledbContext.Departments.FindAsync(id); // SELECT * FROM DEPARTMENTS WHERE ID = {id}

            return Ok(departments);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post(CreateDepartmentRequest request)
        {


            Department departmentObj
                 = new Department()
                 {
                     DepartmentName = request.DepartmentName
                 };


            await sampledbContext.Departments.AddAsync(departmentObj);

            var response = await sampledbContext.SaveChangesAsync();

            return Created("/api/Department", "Department Created Successfully");
        }


    }
}
