namespace efcore_navigation.RequestModel
{
    public class CreateUserRequest
    {
        public string Name { get; set; } = default!;

        public string Email { get; set; } = default!;

        public string DepartmentName { get; set; } = default!;


        public CreateUserProfileRequest UserProfile { get; set; } = new();
    }



    public class CreateUserProfileRequest
    {
        public string Address { get; set; } = default!;

        public string City { get; set; } = default!;

        public string Country { get; set; } = default!;

    }
}
