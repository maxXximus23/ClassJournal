using Microsoft.EntityFrameworkCore;

namespace ClassJournal.DataAccess
{
    public class DatabaseContext : DbContext
    {
        
        
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {
                
        }
    }
}