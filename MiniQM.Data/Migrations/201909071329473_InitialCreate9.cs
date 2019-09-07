namespace MiniQM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate9 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.OrderTypes", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.OrderTypes", "TypeCode", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.OrderTypes", "Description", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrderTypes", "Description", c => c.String());
            AlterColumn("dbo.OrderTypes", "TypeCode", c => c.String());
            AlterColumn("dbo.OrderTypes", "Name", c => c.String());
            AlterColumn("dbo.Orders", "Name", c => c.String());
        }
    }
}
