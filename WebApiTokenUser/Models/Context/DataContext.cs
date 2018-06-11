using System.Data.Entity;

namespace WebApiTokenUser.Models.Context
{
    public class DataContext: DbContext
    {
        public DataContext()
            : base("DbConnection")
        { }

        public DbSet<Data> Data { get; set; }
    }
}