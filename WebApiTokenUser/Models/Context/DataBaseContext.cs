using System.Data.Entity;

namespace WebApiTokenUser.Models.Context
{
    public class DataBaseContext: DbContext
    {
        public DataBaseContext()
            : base("DbConnection")
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Data> Data { get; set; }
    }
}