using System;
using ClassJournal.Domain.Auth;
using Microsoft.EntityFrameworkCore;

namespace ClassJournal.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {
                
        }
    }
}