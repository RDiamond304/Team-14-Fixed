namespace System_Project_Group14.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSetup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "User_UserID", c => c.Int());
            CreateIndex("dbo.Companies", "User_UserID");
            AddForeignKey("dbo.Companies", "User_UserID", "dbo.Users", "UserID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Companies", "User_UserID", "dbo.Users");
            DropIndex("dbo.Companies", new[] { "User_UserID" });
            DropColumn("dbo.Companies", "User_UserID");
        }
    }
}
