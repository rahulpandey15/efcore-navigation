using Microsoft.EntityFrameworkCore;

namespace efcore_navigation.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<SampledbContext>();
            

            if (!context.Departments.Any())
            {
                context.Departments.AddRange(
                    new Department { DepartmentName = "Inventory" },
                    new Department { DepartmentName = "HumanResource" },
                    new Department { DepartmentName = "SupplyChain" }
                );
                context.SaveChanges();
            }
        }
    }
}
