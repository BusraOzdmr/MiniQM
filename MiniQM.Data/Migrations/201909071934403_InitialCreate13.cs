namespace MiniQM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate13 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sectors", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Sectors", "Description", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sectors", "Description", c => c.String());
            AlterColumn("dbo.Sectors", "Name", c => c.String());
        }
    }
}
