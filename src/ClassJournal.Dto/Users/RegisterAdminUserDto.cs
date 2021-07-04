namespace ClassJournal.Dto.Users
{
    public class RegisterAdminUserDto
    {
        public string UserName { get; set; }
        
        public string PasswordHash { get; set; }
        
        public string Role { get; set; }
    }
}