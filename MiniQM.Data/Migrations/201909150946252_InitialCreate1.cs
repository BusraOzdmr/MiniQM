namespace MiniQM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BusinessAreas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 4000),
                        MainAreaId = c.Int(),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
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
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
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
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BusinessAreas", t => t.BusinessAreaId, cascadeDelete: true)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .ForeignKey("dbo.Facilities", t => t.FacilityId)
                .ForeignKey("dbo.OrderTypes", t => t.OrderTypeId, cascadeDelete: true)
                .ForeignKey("dbo.PurchasingDepartments", t => t.PurchasingDepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.CompanyId)
                .Index(t => t.FacilityId)
                .Index(t => t.BusinessAreaId)
                .Index(t => t.PurchasingDepartmentId)
                .Index(t => t.OrderTypeId)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        CompanyId = c.Int(),
                        FacilityId = c.Int(),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
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
                "dbo.Facilities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        CompanyId = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
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
            
            CreateTable(
                "dbo.ProductionEquipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LanguageId = c.Int(),
                        CompanyId = c.Int(),
                        FacilityId = c.Int(),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 4000),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
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
                .ForeignKey("dbo.Languages", t => t.LanguageId)
                .Index(t => t.LanguageId)
                .Index(t => t.CompanyId)
                .Index(t => t.FacilityId);
            
            CreateTable(
                "dbo.ChangeQualityPlans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QualityPlanId = c.Int(nullable: false),
                        MaterialId = c.Int(),
                        CriterionId = c.Int(),
                        IsDynamic = c.Boolean(nullable: false),
                        IsDetailed = c.Boolean(nullable: false),
                        UnitId = c.Int(),
                        CertificateId = c.Int(),
                        Level = c.Int(),
                        Contrafactor = c.Decimal(precision: 18, scale: 2),
                        AQL = c.Int(),
                        ProductionEquipmentId = c.Int(),
                        NominalSize = c.Decimal(precision: 18, scale: 2),
                        MaxSize = c.Decimal(precision: 18, scale: 2),
                        MinSize = c.Decimal(precision: 18, scale: 2),
                        PurchasingControl = c.Boolean(nullable: false),
                        ProductionControl = c.Boolean(nullable: false),
                        Description = c.String(maxLength: 4000),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Certificates", t => t.CertificateId)
                .ForeignKey("dbo.Criteria", t => t.CriterionId)
                .ForeignKey("dbo.Materials", t => t.MaterialId)
                .ForeignKey("dbo.ProductionEquipments", t => t.ProductionEquipmentId)
                .ForeignKey("dbo.QualityPlans", t => t.QualityPlanId, cascadeDelete: true)
                .ForeignKey("dbo.Units", t => t.UnitId)
                .Index(t => t.QualityPlanId)
                .Index(t => t.MaterialId)
                .Index(t => t.CriterionId)
                .Index(t => t.UnitId)
                .Index(t => t.CertificateId)
                .Index(t => t.ProductionEquipmentId);
            
            CreateTable(
                "dbo.Certificates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 4000),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Criteria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Level = c.Int(nullable: false),
                        CertificateId = c.Int(nullable: false),
                        Contrafactor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AQL = c.Int(nullable: false),
                        IsDynamic = c.Boolean(nullable: false),
                        IsDetailed = c.Boolean(nullable: false),
                        UnitId = c.Int(),
                        ProductionEquipmentId = c.Int(),
                        SystemUserId = c.Int(),
                        UserGroupId = c.Int(),
                        IsCritical = c.Boolean(nullable: false),
                        NominalSize = c.Decimal(precision: 18, scale: 2),
                        MaxSize = c.Decimal(precision: 18, scale: 2),
                        MinSize = c.Decimal(precision: 18, scale: 2),
                        PurchasingControl = c.Boolean(nullable: false),
                        ProductionControl = c.Boolean(nullable: false),
                        Description = c.String(maxLength: 4000),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Certificates", t => t.CertificateId, cascadeDelete: true)
                .ForeignKey("dbo.ProductionEquipments", t => t.ProductionEquipmentId)
                .ForeignKey("dbo.SystemUsers", t => t.SystemUserId)
                .ForeignKey("dbo.Units", t => t.UnitId)
                .ForeignKey("dbo.UserGroups", t => t.UserGroupId)
                .Index(t => t.CertificateId)
                .Index(t => t.UnitId)
                .Index(t => t.ProductionEquipmentId)
                .Index(t => t.SystemUserId)
                .Index(t => t.UserGroupId);
            
            CreateTable(
                "dbo.SystemUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 100),
                        ContactNumber = c.String(maxLength: 15),
                        Name = c.String(nullable: false, maxLength: 100),
                        Surname = c.String(nullable: false, maxLength: 100),
                        ContactType = c.Int(nullable: false),
                        Email = c.String(nullable: false, maxLength: 100),
                        CompanyId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        PositionId = c.Int(),
                        Profile = c.String(maxLength: 500),
                        FilePath = c.String(maxLength: 500),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Positions", t => t.PositionId)
                .Index(t => t.CompanyId)
                .Index(t => t.DepartmentId)
                .Index(t => t.PositionId);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        DepartmentId = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LanguageId = c.Int(),
                        Name = c.String(nullable: false, maxLength: 100),
                        Factor = c.Decimal(precision: 18, scale: 2),
                        Description = c.String(maxLength: 4000),
                        UnitCategory = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Languages", t => t.LanguageId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Code = c.String(),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        LanguageId = c.Int(),
                        Description = c.String(maxLength: 4000),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Languages", t => t.LanguageId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 500),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
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
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
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
                        Name = c.String(nullable: false, maxLength: 100),
                        TypeCode = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 4000),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
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
                        Name = c.String(nullable: false, maxLength: 100),
                        CompanyId = c.Int(),
                        FacilityId = c.Int(),
                        Warehouse = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 4000),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
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
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(),
                        Name = c.String(nullable: false, maxLength: 100),
                        BusinessAreaId = c.Int(),
                        SectorId = c.Int(nullable: false),
                        CountryId = c.Int(),
                        CityId = c.Int(),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BusinessAreas", t => t.BusinessAreaId)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .ForeignKey("dbo.Countries", t => t.CountryId)
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
                        Name = c.String(nullable: false, maxLength: 100),
                        CountryId = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
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
                        Name = c.String(nullable: false, maxLength: 100),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sectors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 4000),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QualityPlans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                        FacilityId = c.Int(),
                        MaterialId = c.Int(nullable: false),
                        Description = c.String(maxLength: 4000),
                        StartDate = c.DateTime(),
                        ClosedDate = c.DateTime(),
                        IsProcess = c.Int(),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.Facilities", t => t.FacilityId)
                .ForeignKey("dbo.Materials", t => t.MaterialId, cascadeDelete: true)
                .Index(t => t.CompanyId)
                .Index(t => t.FacilityId)
                .Index(t => t.MaterialId);
            
            CreateTable(
                "dbo.PurchasingDepartments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
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
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Orders", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Orders", "PurchasingDepartmentId", "dbo.PurchasingDepartments");
            DropForeignKey("dbo.Orders", "OrderTypeId", "dbo.OrderTypes");
            DropForeignKey("dbo.Orders", "FacilityId", "dbo.Facilities");
            DropForeignKey("dbo.Orders", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.PurchasingDepartments", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Departments", "FacilityId", "dbo.Facilities");
            DropForeignKey("dbo.ProductionEquipments", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.ProductionEquipments", "FacilityId", "dbo.Facilities");
            DropForeignKey("dbo.ProductionEquipments", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.ChangeQualityPlans", "UnitId", "dbo.Units");
            DropForeignKey("dbo.ChangeQualityPlans", "QualityPlanId", "dbo.QualityPlans");
            DropForeignKey("dbo.ChangeQualityPlans", "ProductionEquipmentId", "dbo.ProductionEquipments");
            DropForeignKey("dbo.ChangeQualityPlans", "MaterialId", "dbo.Materials");
            DropForeignKey("dbo.QualityPlans", "MaterialId", "dbo.Materials");
            DropForeignKey("dbo.QualityPlans", "FacilityId", "dbo.Facilities");
            DropForeignKey("dbo.QualityPlans", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.MaterialInputs", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Suppliers", "SectorId", "dbo.Sectors");
            DropForeignKey("dbo.Suppliers", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Suppliers", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Suppliers", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Cities", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Suppliers", "BusinessAreaId", "dbo.BusinessAreas");
            DropForeignKey("dbo.MaterialInputs", "StockLocationId", "dbo.StockLocations");
            DropForeignKey("dbo.StockLocations", "FacilityId", "dbo.Facilities");
            DropForeignKey("dbo.StockLocations", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.MaterialInputs", "OrderTypeId", "dbo.OrderTypes");
            DropForeignKey("dbo.MaterialInputs", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.MaterialInputs", "MaterialId", "dbo.Materials");
            DropForeignKey("dbo.ChangeQualityPlans", "CriterionId", "dbo.Criteria");
            DropForeignKey("dbo.ChangeQualityPlans", "CertificateId", "dbo.Certificates");
            DropForeignKey("dbo.Criteria", "UserGroupId", "dbo.UserGroups");
            DropForeignKey("dbo.Criteria", "UnitId", "dbo.Units");
            DropForeignKey("dbo.Units", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.UserGroups", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.Criteria", "SystemUserId", "dbo.SystemUsers");
            DropForeignKey("dbo.SystemUsers", "PositionId", "dbo.Positions");
            DropForeignKey("dbo.Positions", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.SystemUsers", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.SystemUsers", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Criteria", "ProductionEquipmentId", "dbo.ProductionEquipments");
            DropForeignKey("dbo.Criteria", "CertificateId", "dbo.Certificates");
            DropForeignKey("dbo.Facilities", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Departments", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Orders", "BusinessAreaId", "dbo.BusinessAreas");
            DropForeignKey("dbo.BusinessAreas", "MainAreaId", "dbo.BusinessAreas");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PurchasingDepartments", new[] { "CompanyId" });
            DropIndex("dbo.QualityPlans", new[] { "MaterialId" });
            DropIndex("dbo.QualityPlans", new[] { "FacilityId" });
            DropIndex("dbo.QualityPlans", new[] { "CompanyId" });
            DropIndex("dbo.Cities", new[] { "CountryId" });
            DropIndex("dbo.Suppliers", new[] { "CityId" });
            DropIndex("dbo.Suppliers", new[] { "CountryId" });
            DropIndex("dbo.Suppliers", new[] { "SectorId" });
            DropIndex("dbo.Suppliers", new[] { "BusinessAreaId" });
            DropIndex("dbo.Suppliers", new[] { "CompanyId" });
            DropIndex("dbo.StockLocations", new[] { "FacilityId" });
            DropIndex("dbo.StockLocations", new[] { "CompanyId" });
            DropIndex("dbo.MaterialInputs", new[] { "StockLocationId" });
            DropIndex("dbo.MaterialInputs", new[] { "SupplierId" });
            DropIndex("dbo.MaterialInputs", new[] { "MaterialId" });
            DropIndex("dbo.MaterialInputs", new[] { "OrderId" });
            DropIndex("dbo.MaterialInputs", new[] { "OrderTypeId" });
            DropIndex("dbo.UserGroups", new[] { "LanguageId" });
            DropIndex("dbo.Units", new[] { "LanguageId" });
            DropIndex("dbo.Positions", new[] { "DepartmentId" });
            DropIndex("dbo.SystemUsers", new[] { "PositionId" });
            DropIndex("dbo.SystemUsers", new[] { "DepartmentId" });
            DropIndex("dbo.SystemUsers", new[] { "CompanyId" });
            DropIndex("dbo.Criteria", new[] { "UserGroupId" });
            DropIndex("dbo.Criteria", new[] { "SystemUserId" });
            DropIndex("dbo.Criteria", new[] { "ProductionEquipmentId" });
            DropIndex("dbo.Criteria", new[] { "UnitId" });
            DropIndex("dbo.Criteria", new[] { "CertificateId" });
            DropIndex("dbo.ChangeQualityPlans", new[] { "ProductionEquipmentId" });
            DropIndex("dbo.ChangeQualityPlans", new[] { "CertificateId" });
            DropIndex("dbo.ChangeQualityPlans", new[] { "UnitId" });
            DropIndex("dbo.ChangeQualityPlans", new[] { "CriterionId" });
            DropIndex("dbo.ChangeQualityPlans", new[] { "MaterialId" });
            DropIndex("dbo.ChangeQualityPlans", new[] { "QualityPlanId" });
            DropIndex("dbo.ProductionEquipments", new[] { "FacilityId" });
            DropIndex("dbo.ProductionEquipments", new[] { "CompanyId" });
            DropIndex("dbo.ProductionEquipments", new[] { "LanguageId" });
            DropIndex("dbo.Facilities", new[] { "CompanyId" });
            DropIndex("dbo.Departments", new[] { "FacilityId" });
            DropIndex("dbo.Departments", new[] { "CompanyId" });
            DropIndex("dbo.Orders", new[] { "SupplierId" });
            DropIndex("dbo.Orders", new[] { "OrderTypeId" });
            DropIndex("dbo.Orders", new[] { "PurchasingDepartmentId" });
            DropIndex("dbo.Orders", new[] { "BusinessAreaId" });
            DropIndex("dbo.Orders", new[] { "FacilityId" });
            DropIndex("dbo.Orders", new[] { "CompanyId" });
            DropIndex("dbo.BusinessAreas", new[] { "MainAreaId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PurchasingDepartments");
            DropTable("dbo.QualityPlans");
            DropTable("dbo.Sectors");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
            DropTable("dbo.Suppliers");
            DropTable("dbo.StockLocations");
            DropTable("dbo.OrderTypes");
            DropTable("dbo.MaterialInputs");
            DropTable("dbo.Materials");
            DropTable("dbo.UserGroups");
            DropTable("dbo.Languages");
            DropTable("dbo.Units");
            DropTable("dbo.Positions");
            DropTable("dbo.SystemUsers");
            DropTable("dbo.Criteria");
            DropTable("dbo.Certificates");
            DropTable("dbo.ChangeQualityPlans");
            DropTable("dbo.ProductionEquipments");
            DropTable("dbo.Facilities");
            DropTable("dbo.Departments");
            DropTable("dbo.Companies");
            DropTable("dbo.Orders");
            DropTable("dbo.BusinessAreas");
        }
    }
}
