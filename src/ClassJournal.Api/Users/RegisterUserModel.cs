﻿namespace ClassJournal.Api.Users
{
    public class RegisterUserModel
    {
        public string UserName { get; set; }
        
        public string Password { get; set; }
        
        public int RoleId { get; set; }
    }
}