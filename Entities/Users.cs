namespace StudentManagementApi.Entities
{
    public class Users
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Stream { get; set; }
        public string? Email { get; set; }
        public long? Phone { get; set; }
    }
}
