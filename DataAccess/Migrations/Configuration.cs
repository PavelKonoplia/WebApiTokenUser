namespace WebApiTokenUser.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using WebApiTokenUser.Entity.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApiTokenUser.DAL.IdentityDatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApiTokenUser.DAL.IdentityDatabaseContext context)
        {
            //  This method will be called after migrating to the latest version.
            User user = new User
            {
                Id = 1,
                UserName = "Nick",
                PasswordHash = "Nick"
            };

            User user2 = new User
            {
                Id = 2,
                UserName = "Jack",
                PasswordHash = "qwerty"
            };

            Data data = new Data
            {
                Id = 1,
                Topic = "Space",
                Description = "Sun is the star!"
            };
            
            Data data2 = new Data
            {
                Id = 2,
                Topic = "Animal",
                Description = "Elephant is biggest animal on the earth."
            };

            try
            {
                // Your code...
                // Could also be before try if you know the exception occurs in SaveChanges
                context.Users.Add(user);

                context.Users.Add(user2);

                context.Data.Add(data2);

                context.Data.Add(data);
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }

                throw;
            }
        }
    }
}
