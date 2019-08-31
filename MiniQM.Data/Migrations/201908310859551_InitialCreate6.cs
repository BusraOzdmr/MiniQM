namespace MiniQM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate6 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ProductionEquipments", name: "Language_Id", newName: "LanguageId");
            RenameIndex(table: "dbo.ProductionEquipments", name: "IX_Language_Id", newName: "IX_LanguageId");
            AlterColumn("dbo.ProductionEquipments", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.ProductionEquipments", "Description", c => c.String(maxLength: 4000));
            DropColumn("dbo.ProductionEquipments", "LangugeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductionEquipments", "LangugeId", c => c.Int());
            AlterColumn("dbo.ProductionEquipments", "Description", c => c.String());
            AlterColumn("dbo.ProductionEquipments", "Name", c => c.String());
            RenameIndex(table: "dbo.ProductionEquipments", name: "IX_LanguageId", newName: "IX_Language_Id");
            RenameColumn(table: "dbo.ProductionEquipments", name: "LanguageId", newName: "Language_Id");
        }
    }
}
