using efcore_navigation.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using efcore_navigation.RequestModel;

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
                     DepartmentName = request.DepartmentName,
                 };

            await sampledbContext.Departments.AddAsync(departmentObj);

            var response = await sampledbContext.SaveChangesAsync();

            return Created("/api/Department", "Department Created Successfully");
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(string departmentName)
        {
            if (string.IsNullOrEmpty(departmentName))
                return BadRequest("DepartmentName cannot be null");

            var param = new SqlParameter("@DepartmentName", departmentName);

            await sampledbContext.Database.ExecuteSqlRawAsync("EXEC dbo.usp_InsertDepartment @DepartmentName", param);

            return Created("/api/Department", "Department Created Successfully");
        }


        [HttpPut]
        public async Task<IActionResult> Update(int departmentId,string updatedName)
        {
            var records
                 = await sampledbContext.Departments
                 .Where(x => x.Id == departmentId) // filtering 
                 .ExecuteUpdateAsync(setter => setter
                    .SetProperty(x => x.DepartmentName, updatedName)
                    .SetProperty(x => x.CreatedBy, "MyDemoUser"));





            //var departmentDetails
            //     = sampledbContext.Departments.Find(departmentId);


            //if (departmentDetails is null)
            //    throw new ArgumentNullException($"No department exists in database with Department Id {departmentId}");

            //departmentDetails.DepartmentName = updatedName;

            //int rowsImpacted = await sampledbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
