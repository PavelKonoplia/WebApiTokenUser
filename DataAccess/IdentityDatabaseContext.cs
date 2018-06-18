using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using WebApiTokenUser.Entity.Models;

namespace WebApiTokenUser.DAL
{

    public class IdentityDatabaseContext : IdentityDbContext<User, CustomRole, long,
        CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public IdentityDatabaseContext() : base("DbConnection") { }

        public DbSet<Data> Data { get; set; }

        static IdentityDatabaseContext()
        {
           // Database.SetInitializer<IdentityDatabaseContext>(new IdentityDbInit());
        }

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
    /*
    public class IdentityDbInit : DropCreateDatabaseIfModelChanges<IdentityDatabaseContext>
    {
        protected override void Seed(IdentityDatabaseContext context)
        {
            PerformInitialSetup(context);
            base.Seed(context);
        }
        public void PerformInitialSetup(IdentityDatabaseContext context)
        {
            User user = new User
            {
                UserName = "Nick",
                PasswordHash = "qwerty"
            };
            context.Users.Add(user);
            User user2 = new User
            {
                UserName = "Jack",
                PasswordHash = "qwerty"
            };
            context.Users.Add(user2);

            Data data = new Data
            {
                Topic = "Space",
                Description = "Sun is the star!"
            };

            context.Data.Add(data);
            Data data2 = new Data
            {
                Topic = "Animal",
                Description = "Elephant is biggest animal on the earth."
            };

            context.Data.Add(data2);
            context.SaveChanges();
        }
    }*/
}

