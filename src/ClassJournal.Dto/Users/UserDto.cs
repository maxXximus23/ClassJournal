namespace ClassJournal.Dto.Users
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public RoleDto Role { get; set; }
        public bool IsActive { get; set; }
    }
}