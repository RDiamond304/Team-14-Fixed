namespace System_Project_Group14.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyUserClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MyUserInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MyUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                        MyUserInfo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MyUserInfoes", t => t.MyUserInfo_Id)
                .Index(t => t.MyUserInfo_Id);
            
            AddColumn("dbo.AspNetUserClaims", "MyUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserLogins", "MyUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserRoles", "MyUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetUserClaims", "MyUser_Id");
            CreateIndex("dbo.AspNetUserLogins", "MyUser_Id");
            CreateIndex("dbo.AspNetUserRoles", "MyUser_Id");
            AddForeignKey("dbo.AspNetUserClaims", "MyUser_Id", "dbo.MyUsers", "Id");
            AddForeignKey("dbo.AspNetUserLogins", "MyUser_Id", "dbo.MyUsers", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "MyUser_Id", "dbo.MyUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "MyUser_Id", "dbo.MyUsers");
            DropForeignKey("dbo.MyUsers", "MyUserInfo_Id", "dbo.MyUserInfoes");
            DropForeignKey("dbo.AspNetUserLogins", "MyUser_Id", "dbo.MyUsers");
            DropForeignKey("dbo.AspNetUserClaims", "MyUser_Id", "dbo.MyUsers");
            DropIndex("dbo.MyUsers", new[] { "MyUserInfo_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "MyUser_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "MyUser_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "MyUser_Id" });
            DropColumn("dbo.AspNetUserRoles", "MyUser_Id");
            DropColumn("dbo.AspNetUserLogins", "MyUser_Id");
            DropColumn("dbo.AspNetUserClaims", "MyUser_Id");
            DropTable("dbo.MyUsers");
            DropTable("dbo.MyUserInfoes");
        }
    }
}
