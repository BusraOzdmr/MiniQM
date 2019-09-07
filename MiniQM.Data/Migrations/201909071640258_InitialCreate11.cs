namespace MiniQM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate11 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BusinessAreas", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.BusinessAreas", "Description", c => c.String(maxLength: 4000));
            AlterColumn("dbo.Suppliers", "Name", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Suppliers", "Name", c => c.String());
            AlterColumn("dbo.BusinessAreas", "Description", c => c.String());
            AlterColumn("dbo.BusinessAreas", "Name", c => c.String());
        }
    }
}
