using efcore_navigation.Data;

namespace efcore_navigation.Data.StoredProcedure
{
    public class FetchEmployeesByDepartment
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Gender { get; set; } = default!;
        public string Address { get;set;} = default!;
        public string City { get; set; } = default!;
        public string Country { get; set; } = default!;
        public string DepartmentName { get; set; } = default!;
    }
}