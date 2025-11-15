namespace efcore_navigation.Data
{
    public class UserProfile
    {
        public int Id { get; set; }

        public string Address { get; set; } = default!;

        public string City { get; set; } = default!;    

        public string Country { get; set; } = default!; 

        public int UserId { get; set; }  // Foreign key

        public User User { get; set; } = default!; // Navigation property

    }
}
