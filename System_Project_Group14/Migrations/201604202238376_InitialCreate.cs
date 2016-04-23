namespace System_Project_Group14.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyID = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false),
                        CompanyDescription = c.String(nullable: false),
                        CompanyEmail = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CompanyID);
            
            CreateTable(
                "dbo.Industries",
                c => new
                    {
                        IndustryID = c.Int(nullable: false, identity: true),
                        IndustryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IndustryID);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        PositionID = c.Int(nullable: false, identity: true),
                        PositionTitle = c.String(nullable: false),
                        PositionDescription = c.String(nullable: false),
                        PositionTypes = c.Int(nullable: false),
                        ApplicableMajor = c.Int(nullable: false),
                        PositionDeadline = c.DateTime(nullable: false),
                        CompanyName_CompanyID = c.Int(),
                        Industry_IndustryID = c.Int(),
                    })
                .PrimaryKey(t => t.PositionID)
                .ForeignKey("dbo.Companies", t => t.CompanyName_CompanyID)
                .ForeignKey("dbo.Industries", t => t.Industry_IndustryID)
                .Index(t => t.CompanyName_CompanyID)
                .Index(t => t.Industry_IndustryID);
            
            CreateTable(
                "dbo.AppliedStudents",
                c => new
                    {
                        AppliedStudentsID = c.Int(nullable: false, identity: true),
                        AppliedToPosition = c.Boolean(nullable: false),
                        Position_PositionID = c.Int(),
                        Student_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.AppliedStudentsID)
                .ForeignKey("dbo.Positions", t => t.Position_PositionID)
                .ForeignKey("dbo.AspNetUsers", t => t.Student_Id)
                .Index(t => t.Position_PositionID)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        StudentID = c.Int(),
                        Major = c.Int(),
                        GradSemester = c.Int(),
                        StudentPosition = c.Int(),
                        GPA = c.Decimal(precision: 18, scale: 2),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        AppUsers_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.AspNetUsers", t => t.AppUsers_Id)
                .Index(t => t.AppUsers_Id);
            
            CreateTable(
                "dbo.Interviews",
                c => new
                    {
                        InterviewID = c.Int(nullable: false, identity: true),
                        CompanyName_CompanyID = c.Int(),
                        PositionName_PositionID = c.Int(),
                        StudentID_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.InterviewID)
                .ForeignKey("dbo.Companies", t => t.CompanyName_CompanyID)
                .ForeignKey("dbo.Positions", t => t.PositionName_PositionID)
                .ForeignKey("dbo.AspNetUsers", t => t.StudentID_Id)
                .Index(t => t.CompanyName_CompanyID)
                .Index(t => t.PositionName_PositionID)
                .Index(t => t.StudentID_Id);
            
            CreateTable(
                "dbo.InterviewTimes",
                c => new
                    {
                        InterviewTimesID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.InterviewTimesID);
            
            CreateTable(
                "dbo.InterviewRoomSchedules",
                c => new
                    {
                        InterviewRoomScheduleID = c.Int(nullable: false, identity: true),
                        InterviewTimes_InterviewTimesID = c.Int(),
                        Room_RoomID = c.Int(),
                    })
                .PrimaryKey(t => t.InterviewRoomScheduleID)
                .ForeignKey("dbo.InterviewTimes", t => t.InterviewTimes_InterviewTimesID)
                .ForeignKey("dbo.Rooms", t => t.Room_RoomID)
                .Index(t => t.InterviewTimes_InterviewTimesID)
                .Index(t => t.Room_RoomID);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomID = c.Int(nullable: false, identity: true),
                        Rooms = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoomID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.IndustryCompanies",
                c => new
                    {
                        Industry_IndustryID = c.Int(nullable: false),
                        Company_CompanyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Industry_IndustryID, t.Company_CompanyID })
                .ForeignKey("dbo.Industries", t => t.Industry_IndustryID, cascadeDelete: true)
                .ForeignKey("dbo.Companies", t => t.Company_CompanyID, cascadeDelete: true)
                .Index(t => t.Industry_IndustryID)
                .Index(t => t.Company_CompanyID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.InterviewRoomSchedules", "Room_RoomID", "dbo.Rooms");
            DropForeignKey("dbo.InterviewRoomSchedules", "InterviewTimes_InterviewTimesID", "dbo.InterviewTimes");
            DropForeignKey("dbo.Interviews", "StudentID_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Interviews", "PositionName_PositionID", "dbo.Positions");
            DropForeignKey("dbo.Interviews", "CompanyName_CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Positions", "Industry_IndustryID", "dbo.Industries");
            DropForeignKey("dbo.Users", "AppUsers_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AppliedStudents", "Student_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AppliedStudents", "Position_PositionID", "dbo.Positions");
            DropForeignKey("dbo.Positions", "CompanyName_CompanyID", "dbo.Companies");
            DropForeignKey("dbo.IndustryCompanies", "Company_CompanyID", "dbo.Companies");
            DropForeignKey("dbo.IndustryCompanies", "Industry_IndustryID", "dbo.Industries");
            DropIndex("dbo.IndustryCompanies", new[] { "Company_CompanyID" });
            DropIndex("dbo.IndustryCompanies", new[] { "Industry_IndustryID" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.InterviewRoomSchedules", new[] { "Room_RoomID" });
            DropIndex("dbo.InterviewRoomSchedules", new[] { "InterviewTimes_InterviewTimesID" });
            DropIndex("dbo.Interviews", new[] { "StudentID_Id" });
            DropIndex("dbo.Interviews", new[] { "PositionName_PositionID" });
            DropIndex("dbo.Interviews", new[] { "CompanyName_CompanyID" });
            DropIndex("dbo.Users", new[] { "AppUsers_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AppliedStudents", new[] { "Student_Id" });
            DropIndex("dbo.AppliedStudents", new[] { "Position_PositionID" });
            DropIndex("dbo.Positions", new[] { "Industry_IndustryID" });
            DropIndex("dbo.Positions", new[] { "CompanyName_CompanyID" });
            DropTable("dbo.IndustryCompanies");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Rooms");
            DropTable("dbo.InterviewRoomSchedules");
            DropTable("dbo.InterviewTimes");
            DropTable("dbo.Interviews");
            DropTable("dbo.Users");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AppliedStudents");
            DropTable("dbo.Positions");
            DropTable("dbo.Industries");
            DropTable("dbo.Companies");
        }
    }
}
