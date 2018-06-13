using System.Data.Entity;
using WebApiTokenUser.Entity.Models;

namespace DataAccess.Models.Context
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext() : base("DbConnection") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Data> Data { get; set; }
    }
}