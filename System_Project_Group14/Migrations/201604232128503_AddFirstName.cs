namespace System_Project_Group14.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFirstName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
