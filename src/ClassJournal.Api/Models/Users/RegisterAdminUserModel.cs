namespace ClassJournal.Api.Models.Users
{
    public class RegisterAdminUserModel
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
    }
}