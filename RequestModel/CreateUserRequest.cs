namespace efcore_navigation.RequestModel
{
    public class CreateUserRequest
    {
        public string Name { get; set; } = default!;

        public string Email { get; set; } = default!;

        public string Gender { get; set; } = default!;
        public string DepartmentName { get; set; } = default!;

        public CreateUserProfileRequest UserProfile { get; set; } = new();
    }
}
