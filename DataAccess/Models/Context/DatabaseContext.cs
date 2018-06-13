using System.Data.Entity;

namespace DataAccess.Models.Context
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext() : base("DbConnection") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Data> Data { get; set; }
    }
}