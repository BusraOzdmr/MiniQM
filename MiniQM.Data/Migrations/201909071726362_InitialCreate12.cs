namespace MiniQM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate12 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StockLocations", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.StockLocations", "Warehouse", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.StockLocations", "Description", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StockLocations", "Description", c => c.String());
            AlterColumn("dbo.StockLocations", "Warehouse", c => c.String());
            AlterColumn("dbo.StockLocations", "Name", c => c.String());
        }
    }
}
