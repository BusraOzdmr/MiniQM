namespace MiniQM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitalCreate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Positions", "Department_Id", "dbo.Departments");
            DropIndex("dbo.Positions", new[] { "Department_Id" });
            RenameColumn(table: "dbo.Positions", name: "Department_Id", newName: "DepartmentId");
            AlterColumn("dbo.Positions", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Positions", "DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Positions", "DepartmentId");
            AddForeignKey("dbo.Positions", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
            DropColumn("dbo.Positions", "DepartmantId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Positions", "DepartmantId", c => c.Int());
            DropForeignKey("dbo.Positions", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Positions", new[] { "DepartmentId" });
            AlterColumn("dbo.Positions", "DepartmentId", c => c.Int());
            AlterColumn("dbo.Positions", "Name", c => c.String(nullable: false));
            RenameColumn(table: "dbo.Positions", name: "DepartmentId", newName: "Department_Id");
            CreateIndex("dbo.Positions", "Department_Id");
            AddForeignKey("dbo.Positions", "Department_Id", "dbo.Departments", "Id");
        }
    }
}
