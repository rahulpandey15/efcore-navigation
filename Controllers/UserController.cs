using efcore_navigation.Data;
using efcore_navigation.RequestModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace efcore_navigation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        private readonly SampledbContext sampledbContext;

        public UserController(SampledbContext sampledbContext)
        {
            this.sampledbContext = sampledbContext;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            var users = await sampledbContext.Users
                .Include(x => x.Department)
                .Include(x => x.Profile)
                .Select(z => new
                {
                    UserName = z.Name,
                    Email = z.Email,
                    DepartmentName = z.Department.DepartmentName,
                    Address = z.Profile.Address,
                    City = z.Profile.City,
                })
                .ToListAsync();


            return Ok(users);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            var departments = await sampledbContext.Users.FindAsync(id); // SELECT * FROM Users WHERE ID = {id}

            return Ok(departments);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post(CreateUserRequest request)
        {


            var department = await sampledbContext.Departments
                .FirstOrDefaultAsync(x => x.DepartmentName.Equals(request.DepartmentName));
            // select top 1 * from dbo.Departments where departmentName = req.department


            if (department != null)
            {
                User user
                     = new User()
                     {
                         Name = request.Name,
                         Email = request.Email,
                         DepartmentId = department.Id,
                         Gender = request.Gender,
                         Profile = new UserProfile()
                         {
                             Address = request.UserProfile.Address,
                             City = request.UserProfile.City,
                             Country = request.UserProfile.Country
                         }
                     };

                var userresponse = await sampledbContext.Users.AddAsync(user);
                int rowsCreated = await sampledbContext.SaveChangesAsync();
            }


            return Created("/api/Department", "Department Created Successfully");
        }


        [HttpGet]
        [Route("fetchByDepartment/{departmentId}")]
        public async Task<IActionResult> FetchByDeparmentId(int departmentId)
        {
            var myParams = new SqlParameter("@Id", departmentId);

            var response =
                      await sampledbContext.FetchEmployeesByDepartments
                        .FromSqlRaw("Exec dbo.usp_FetchEmployeesByDepartmentId @Id", myParams)
                        .ToListAsync();

            return Ok(response);
        }


    }
}
