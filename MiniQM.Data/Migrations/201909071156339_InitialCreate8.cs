namespace MiniQM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate8 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CompanyId = c.Int(),
                        FacilityId = c.Int(),
                        BusinessAreaId = c.Int(nullable: false),
                        PurchasingDepartmentId = c.Int(nullable: false),
                        OrderTypeId = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        SupplierId = c.Int(nullable: false),
                        Gross = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(),
                        IsDeleted = c.Boolean(),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BusinessAreas", t => t.BusinessAreaId, cascadeDelete: true)
                .ForeignKey("dbo.OrderTypes", t => t.OrderTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .ForeignKey("dbo.Facilities", t => t.FacilityId)
                .ForeignKey("dbo.PurchasingDepartments", t => t.PurchasingDepartmentId, cascadeDelete: true)
                .Index(t => t.CompanyId)
                .Index(t => t.FacilityId)
                .Index(t => t.BusinessAreaId)
                .Index(t => t.PurchasingDepartmentId)
                .Index(t => t.OrderTypeId)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.BusinessAreas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        MainAreaId = c.Int(),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(),
                        IsDeleted = c.Boolean(),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BusinessAreas", t => t.MainAreaId)
                .Index(t => t.MainAreaId);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(),
                        Name = c.String(),
                        BusinessAreaId = c.Int(),
                        SectorId = c.Int(nullable: false),
                        CountryId = c.Int(),
                        CityId = c.Int(),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(),
                        IsDeleted = c.Boolean(),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BusinessAreas", t => t.BusinessAreaId)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .ForeignKey("dbo.Sectors", t => t.SectorId, cascadeDelete: true)
                .Index(t => t.CompanyId)
                .Index(t => t.BusinessAreaId)
                .Index(t => t.SectorId)
                .Index(t => t.CountryId)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CountryId = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(),
                        IsDeleted = c.Boolean(),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(),
                        IsDeleted = c.Boolean(),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MaterialInputs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderTypeId = c.Int(),
                        OrderId = c.Int(),
                        Cost = c.Decimal(precision: 18, scale: 2),
                        MaterialId = c.Int(nullable: false),
                        InputAmount = c.Decimal(precision: 18, scale: 2),
                        SampleAmount = c.Decimal(precision: 18, scale: 2),
                        MaterialQuality = c.Int(nullable: false),
                        Returned = c.Decimal(precision: 18, scale: 2),
                        SupplierId = c.Int(nullable: false),
                        StockLocationId = c.Int(nullable: false),
                        Checked = c.Boolean(nullable: false),
                        QualityControlStatus = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(),
                        IsDeleted = c.Boolean(),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Materials", t => t.MaterialId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId)
                .ForeignKey("dbo.OrderTypes", t => t.OrderTypeId)
                .ForeignKey("dbo.StockLocations", t => t.StockLocationId, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.OrderTypeId)
                .Index(t => t.OrderId)
                .Index(t => t.MaterialId)
                .Index(t => t.SupplierId)
                .Index(t => t.StockLocationId);
            
            CreateTable(
                "dbo.OrderTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TypeCode = c.String(),
                        Description = c.String(),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(),
                        IsDeleted = c.Boolean(),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StockLocations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CompanyId = c.Int(),
                        FacilityId = c.Int(),
                        Warehouse = c.String(),
                        Description = c.String(),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(),
                        IsDeleted = c.Boolean(),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .ForeignKey("dbo.Facilities", t => t.FacilityId)
                .Index(t => t.CompanyId)
                .Index(t => t.FacilityId);
            
            CreateTable(
                "dbo.Sectors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(),
                        IsDeleted = c.Boolean(),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PurchasingDepartments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                        Name = c.String(),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(),
                        IsDeleted = c.Boolean(),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "PurchasingDepartmentId", "dbo.PurchasingDepartments");
            DropForeignKey("dbo.PurchasingDepartments", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Orders", "FacilityId", "dbo.Facilities");
            DropForeignKey("dbo.Orders", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Suppliers", "SectorId", "dbo.Sectors");
            DropForeignKey("dbo.Orders", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.MaterialInputs", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.MaterialInputs", "StockLocationId", "dbo.StockLocations");
            DropForeignKey("dbo.StockLocations", "FacilityId", "dbo.Facilities");
            DropForeignKey("dbo.StockLocations", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.MaterialInputs", "OrderTypeId", "dbo.OrderTypes");
            DropForeignKey("dbo.Orders", "OrderTypeId", "dbo.OrderTypes");
            DropForeignKey("dbo.MaterialInputs", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.MaterialInputs", "MaterialId", "dbo.Materials");
            DropForeignKey("dbo.Suppliers", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Suppliers", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Suppliers", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Cities", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Suppliers", "BusinessAreaId", "dbo.BusinessAreas");
            DropForeignKey("dbo.Orders", "BusinessAreaId", "dbo.BusinessAreas");
            DropForeignKey("dbo.BusinessAreas", "MainAreaId", "dbo.BusinessAreas");
            DropIndex("dbo.PurchasingDepartments", new[] { "CompanyId" });
            DropIndex("dbo.StockLocations", new[] { "FacilityId" });
            DropIndex("dbo.StockLocations", new[] { "CompanyId" });
            DropIndex("dbo.MaterialInputs", new[] { "StockLocationId" });
            DropIndex("dbo.MaterialInputs", new[] { "SupplierId" });
            DropIndex("dbo.MaterialInputs", new[] { "MaterialId" });
            DropIndex("dbo.MaterialInputs", new[] { "OrderId" });
            DropIndex("dbo.MaterialInputs", new[] { "OrderTypeId" });
            DropIndex("dbo.Cities", new[] { "CountryId" });
            DropIndex("dbo.Suppliers", new[] { "CityId" });
            DropIndex("dbo.Suppliers", new[] { "CountryId" });
            DropIndex("dbo.Suppliers", new[] { "SectorId" });
            DropIndex("dbo.Suppliers", new[] { "BusinessAreaId" });
            DropIndex("dbo.Suppliers", new[] { "CompanyId" });
            DropIndex("dbo.BusinessAreas", new[] { "MainAreaId" });
            DropIndex("dbo.Orders", new[] { "SupplierId" });
            DropIndex("dbo.Orders", new[] { "OrderTypeId" });
            DropIndex("dbo.Orders", new[] { "PurchasingDepartmentId" });
            DropIndex("dbo.Orders", new[] { "BusinessAreaId" });
            DropIndex("dbo.Orders", new[] { "FacilityId" });
            DropIndex("dbo.Orders", new[] { "CompanyId" });
            DropTable("dbo.PurchasingDepartments");
            DropTable("dbo.Sectors");
            DropTable("dbo.StockLocations");
            DropTable("dbo.OrderTypes");
            DropTable("dbo.MaterialInputs");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
            DropTable("dbo.Suppliers");
            DropTable("dbo.BusinessAreas");
            DropTable("dbo.Orders");
        }
    }
}
