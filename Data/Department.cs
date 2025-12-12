namespace efcore_navigation.Data
{
    public class Department : AuditEntity
    {
        public int Id { get; set; }

        public string DepartmentName { get; set; } = default!;

        public ICollection<User> Users { get; set; } = []; // Navigation property


      
    }
}
