namespace efcore_navigation.Data
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public string Email { get; set; } = default!;

        public int DepartmentId { get; set; } // Foreign key

        public Department Department { get; set; } = default!; // Navigation property

        public UserProfile Profile { get; set; } = default!; // Navigation property
    }
}
