using Microsoft.EntityFrameworkCore;
using PasswordHashingDemo.Models;

namespace PasswordHashingDemo.Data
{
    public class UserContext:DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }
    }
}
