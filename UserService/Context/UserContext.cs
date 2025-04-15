
using Microsoft.EntityFrameworkCore;
using UserService.Models;

namespace UserService.Context

{
    public class UserContext : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Role> roles { get; set; }

        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }
    }
}
