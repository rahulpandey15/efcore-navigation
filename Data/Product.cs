namespace efcore_navigation.Data
{
    public class Product : AuditEntity
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = default!;
    }
}
