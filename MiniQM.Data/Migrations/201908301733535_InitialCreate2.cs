namespace MiniQM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SystemUsers", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.SystemUsers", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.SystemUsers", new[] { "CompanyId" });
            DropIndex("dbo.SystemUsers", new[] { "DepartmentId" });
            AlterColumn("dbo.SystemUsers", "UserName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.SystemUsers", "ContactNumber", c => c.String(maxLength: 15));
            AlterColumn("dbo.SystemUsers", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.SystemUsers", "Surname", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.SystemUsers", "Email", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.SystemUsers", "CompanyId", c => c.Int(nullable: false));
            AlterColumn("dbo.SystemUsers", "DepartmentId", c => c.Int(nullable: false));
            AlterColumn("dbo.SystemUsers", "Profile", c => c.String(maxLength: 500));
            AlterColumn("dbo.SystemUsers", "FilePath", c => c.String(maxLength: 500));
            CreateIndex("dbo.SystemUsers", "CompanyId");
            CreateIndex("dbo.SystemUsers", "DepartmentId");
            AddForeignKey("dbo.SystemUsers", "CompanyId", "dbo.Companies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SystemUsers", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SystemUsers", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.SystemUsers", "CompanyId", "dbo.Companies");
            DropIndex("dbo.SystemUsers", new[] { "DepartmentId" });
            DropIndex("dbo.SystemUsers", new[] { "CompanyId" });
            AlterColumn("dbo.SystemUsers", "FilePath", c => c.String(nullable: false));
            AlterColumn("dbo.SystemUsers", "Profile", c => c.String(nullable: false));
            AlterColumn("dbo.SystemUsers", "DepartmentId", c => c.Int());
            AlterColumn("dbo.SystemUsers", "CompanyId", c => c.Int());
            AlterColumn("dbo.SystemUsers", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.SystemUsers", "Surname", c => c.String(nullable: false));
            AlterColumn("dbo.SystemUsers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.SystemUsers", "ContactNumber", c => c.String());
            AlterColumn("dbo.SystemUsers", "UserName", c => c.String(nullable: false));
            CreateIndex("dbo.SystemUsers", "DepartmentId");
            CreateIndex("dbo.SystemUsers", "CompanyId");
            AddForeignKey("dbo.SystemUsers", "DepartmentId", "dbo.Departments", "Id");
            AddForeignKey("dbo.SystemUsers", "CompanyId", "dbo.Companies", "Id");
        }
    }
}
