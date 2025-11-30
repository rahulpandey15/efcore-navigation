using efcore_navigation.Data;
using efcore_navigation.Data.StoredProcedure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace efcore_navigation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly SampledbContext dbContext;

        public ProductController(SampledbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var topParam = new SqlParameter("@TopCount", 5);
            var totalCountParam = new SqlParameter
            {
                ParameterName = "@TotalCount",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            var products = await dbContext.Set<GetTopProductResult>()
                .FromSqlRaw("EXEC dbo.GetTopProducts @TopCount, @TotalCount OUTPUT", topParam, totalCountParam)
                .ToListAsync();

            int totalCount = (int)totalCountParam.Value;
            return Ok(totalCount);
        }
    }
}
