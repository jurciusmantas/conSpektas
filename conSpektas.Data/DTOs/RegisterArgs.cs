namespace conSpektas.Data.DTOs
{
    public class RegisterArgs
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string Institution { get; set; }
    }
}
