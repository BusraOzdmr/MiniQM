namespace MiniQM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BusinessAreas", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.BusinessAreas", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.Orders", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.Orders", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.Companies", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.Companies", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.Departments", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.Departments", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.Facilities", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.Facilities", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.ProductionEquipments", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.ProductionEquipments", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.ChangeQualityPlans", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.ChangeQualityPlans", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.Certificates", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.Certificates", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.Criteria", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.Criteria", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.SystemUsers", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.SystemUsers", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.Positions", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.Positions", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.Units", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.Units", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.Languages", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.Languages", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.UserGroups", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.UserGroups", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.Materials", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.Materials", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.MaterialInputs", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.MaterialInputs", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.OrderTypes", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.OrderTypes", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.StockLocations", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.StockLocations", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.Suppliers", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.Suppliers", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.Cities", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.Cities", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.Countries", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.Countries", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.Sectors", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.Sectors", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.QualityPlans", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.QualityPlans", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.PurchasingDepartments", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.PurchasingDepartments", "UpdatedAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PurchasingDepartments", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PurchasingDepartments", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.QualityPlans", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.QualityPlans", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Sectors", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Sectors", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Countries", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Countries", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Cities", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Cities", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Suppliers", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Suppliers", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.StockLocations", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.StockLocations", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.OrderTypes", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.OrderTypes", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.MaterialInputs", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.MaterialInputs", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Materials", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Materials", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.UserGroups", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.UserGroups", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Languages", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Languages", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Units", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Units", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Positions", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Positions", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.SystemUsers", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.SystemUsers", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Criteria", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Criteria", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Certificates", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Certificates", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ChangeQualityPlans", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ChangeQualityPlans", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProductionEquipments", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProductionEquipments", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Facilities", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Facilities", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Departments", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Departments", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Companies", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Companies", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Orders", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Orders", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.BusinessAreas", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.BusinessAreas", "CreatedAt", c => c.DateTime(nullable: false));
        }
    }
}
