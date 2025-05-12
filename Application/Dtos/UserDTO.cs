namespace Applications.DTOs
{
    public class UserDTO
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public string Password { get; set; }
    }
}