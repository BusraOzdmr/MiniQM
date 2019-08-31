namespace MiniQM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Units", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Units", "Factor", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Units", "Description", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Units", "Description", c => c.String());
            AlterColumn("dbo.Units", "Factor", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Units", "Name", c => c.String(nullable: false));
        }
    }
}
