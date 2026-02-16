using efcore_navigation.Data;
using efcore_navigation.Data.StoredProcedure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Drawing;

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
        [HttpPost]
        public IActionResult Post()
        {

            Console.ForegroundColor = ConsoleColor.Red;
            Product p
                 = new Product()
                 {
                     ProductName = "Mobile",
                     CreatedBy = "Sytem",
                     CreatedDate = DateTime.UtcNow
                 };

            Console.WriteLine($"The current state of product is ${dbContext.Entry(p).State}");


            dbContext.Products.Add(p);

            Console.WriteLine($"The current state of product is ${dbContext.Entry(p).State}");


            dbContext.SaveChanges();


            return Ok();
        }




        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
         Console.ForegroundColor = ConsoleColor.Red;

            var product
                  = dbContext.Products.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();

            Console.WriteLine($"The current state of Product Entity is {dbContext.Entry(product).State}");

            product.ProductName = "Monitor";

           Console.WriteLine($"The current state of Product Entity is {dbContext.Entry(product).State}");





            return Ok(product);
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
