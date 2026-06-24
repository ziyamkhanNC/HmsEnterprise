using Microsoft.EntityFrameworkCore;
using Hms.server.Models;

namespace Hms.Server.Models
{
     public class AppDbContext : DbContext
     {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(optiions)
        {
        }
        
        // Representation of the Users table in the DataBase
        public DbSet<User> Users { get; set; } 
     }
}