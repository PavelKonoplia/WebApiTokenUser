using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using WebApiTokenUser.Entity.Models;

namespace WebApiTokenUser.DAL
{
    public class IdentityDatabaseContext : IdentityDbContext<User, CustomRole, long,
        CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public IdentityDatabaseContext() : base("DbConnection")
        {
        }

        public DbSet<Data> Data { get; set; }

        public static IdentityDatabaseContext Create()
        {
            return new IdentityDatabaseContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .ToTable("Users");
        }
    }   
}