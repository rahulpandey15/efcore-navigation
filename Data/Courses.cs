namespace efcore_navigation.Data
{
    public class Courses
    {
        public int Id { get; set; }
        public string CourseName { get; set; } = default!;
        public ICollection<Student> Students { get; set; } = []; // Navigation property

    }
}
