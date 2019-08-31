namespace MiniQM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ChangeQualityPlans", "CriterionId", "dbo.Criteria");
            DropForeignKey("dbo.ChangeQualityPlans", "QualityPlanId", "dbo.QualityPlans");
            DropIndex("dbo.ChangeQualityPlans", new[] { "QualityPlanId" });
            DropIndex("dbo.ChangeQualityPlans", new[] { "CriterionId" });
            RenameColumn(table: "dbo.ChangeQualityPlans", name: "ProductionEquipment_Id", newName: "ProductionEquipmentId");
            RenameIndex(table: "dbo.ChangeQualityPlans", name: "IX_ProductionEquipment_Id", newName: "IX_ProductionEquipmentId");
            AlterColumn("dbo.ChangeQualityPlans", "QualityPlanId", c => c.Int(nullable: false));
            AlterColumn("dbo.ChangeQualityPlans", "CriterionId", c => c.Int());
            AlterColumn("dbo.ChangeQualityPlans", "Description", c => c.String(maxLength: 4000));
            AlterColumn("dbo.Certificates", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Certificates", "Description", c => c.String(maxLength: 4000));
            CreateIndex("dbo.ChangeQualityPlans", "QualityPlanId");
            CreateIndex("dbo.ChangeQualityPlans", "CriterionId");
            AddForeignKey("dbo.ChangeQualityPlans", "CriterionId", "dbo.Criteria", "Id");
            AddForeignKey("dbo.ChangeQualityPlans", "QualityPlanId", "dbo.QualityPlans", "Id", cascadeDelete: true);
            DropColumn("dbo.ChangeQualityPlans", "ProductionEquipmentName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ChangeQualityPlans", "ProductionEquipmentName", c => c.String());
            DropForeignKey("dbo.ChangeQualityPlans", "QualityPlanId", "dbo.QualityPlans");
            DropForeignKey("dbo.ChangeQualityPlans", "CriterionId", "dbo.Criteria");
            DropIndex("dbo.ChangeQualityPlans", new[] { "CriterionId" });
            DropIndex("dbo.ChangeQualityPlans", new[] { "QualityPlanId" });
            AlterColumn("dbo.Certificates", "Description", c => c.String(nullable: false, maxLength: 4000));
            AlterColumn("dbo.Certificates", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.ChangeQualityPlans", "Description", c => c.String());
            AlterColumn("dbo.ChangeQualityPlans", "CriterionId", c => c.Int(nullable: false));
            AlterColumn("dbo.ChangeQualityPlans", "QualityPlanId", c => c.Int());
            RenameIndex(table: "dbo.ChangeQualityPlans", name: "IX_ProductionEquipmentId", newName: "IX_ProductionEquipment_Id");
            RenameColumn(table: "dbo.ChangeQualityPlans", name: "ProductionEquipmentId", newName: "ProductionEquipment_Id");
            CreateIndex("dbo.ChangeQualityPlans", "CriterionId");
            CreateIndex("dbo.ChangeQualityPlans", "QualityPlanId");
            AddForeignKey("dbo.ChangeQualityPlans", "QualityPlanId", "dbo.QualityPlans", "Id");
            AddForeignKey("dbo.ChangeQualityPlans", "CriterionId", "dbo.Criteria", "Id", cascadeDelete: true);
        }
    }
}
