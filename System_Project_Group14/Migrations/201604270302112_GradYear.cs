namespace System_Project_Group14.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GradYear : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Companies", "CompanyIndustry_IndustryID", "dbo.Industries");
            DropIndex("dbo.Companies", new[] { "CompanyIndustry_IndustryID" });
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
            
            AddColumn("dbo.AspNetUsers", "GradYear", c => c.Int());
            DropColumn("dbo.Companies", "CompanyIndustry_IndustryID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Companies", "CompanyIndustry_IndustryID", c => c.Int());
            DropForeignKey("dbo.IndustryCompanies", "Company_CompanyID", "dbo.Companies");
            DropForeignKey("dbo.IndustryCompanies", "Industry_IndustryID", "dbo.Industries");
            DropIndex("dbo.IndustryCompanies", new[] { "Company_CompanyID" });
            DropIndex("dbo.IndustryCompanies", new[] { "Industry_IndustryID" });
            DropColumn("dbo.AspNetUsers", "GradYear");
            DropTable("dbo.IndustryCompanies");
            CreateIndex("dbo.Companies", "CompanyIndustry_IndustryID");
            AddForeignKey("dbo.Companies", "CompanyIndustry_IndustryID", "dbo.Industries", "IndustryID");
        }
    }
}
