using System.Data.Entity;

namespace WebApiTokenUser.Models.Context
{
    public class UserContext : DbContext
    {
        public UserContext()
            : base("DbConnection")
        { }

        public DbSet<User> Users { get; set; }
    }
}