using System.Collections.Generic;
using System.Data.Entity;

namespace WebApiTokenUser.Models.Context
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<DataBaseContext>
    {
        protected override void Seed(DataBaseContext context)
        {
            base.Seed(context);


            User user = new User
            {
                Name = "Nick",
                Loggin = "Nick",
                Password = "qwerty"
            };
            context.Users.Add(user);
            User user2 = new User
            {
                Name = "Jack",
                Loggin = "Jack",
                Password = "qwerty"
            };
            context.Users.Add(user2);


            Data data = new Data
            {
                Topic = "Space",
                Description = "Sun is star"
            };

            context.Data.Add(data);
            Data data2 = new Data
            {
                Topic = "Animal",
                Description = "Elephant is biggest animal on the earth"
            };

            context.Data.Add(data2);


            context.SaveChanges();
        }
    }
}