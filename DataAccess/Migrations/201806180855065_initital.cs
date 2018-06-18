namespace WebApiTokenUser.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initital : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "Name");
            DropColumn("dbo.Users", "Login");
            DropColumn("dbo.Users", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Password", c => c.String());
            AddColumn("dbo.Users", "Login", c => c.String());
            AddColumn("dbo.Users", "Name", c => c.String());
        }
    }
}
