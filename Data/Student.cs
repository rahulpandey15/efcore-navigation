namespace efcore_navigation.Data
{
    public class Student
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;

        public ICollection<Courses> Courses { get; set; } = []; // Navigation property

    }
}
