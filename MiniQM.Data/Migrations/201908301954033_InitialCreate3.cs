namespace MiniQM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Languages", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.UserGroups", "Name", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserGroups", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Languages", "Name", c => c.String());
        }
    }
}
