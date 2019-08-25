namespace MiniQM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
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
                        Name = c.String(nullable: false),
                        CompanyId = c.Int(),
                        CompanyName = c.String(),
                        FacilityId = c.Int(),
                        FacilityName = c.String(),
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
                        Name = c.String(nullable: false),
                        CompanyId = c.Int(),
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
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.ProductionEquipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LangugeId = c.Int(),
                        CompanyId = c.Int(),
                        FacilityId = c.Int(),
                        Name = c.String(),
                        Description = c.String(),
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
                        Language_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Languages", t => t.Language_Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .ForeignKey("dbo.Facilities", t => t.FacilityId)
                .Index(t => t.CompanyId)
                .Index(t => t.FacilityId)
                .Index(t => t.Language_Id);
            
            CreateTable(
                "dbo.ChangeQualityPlans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QualityPlanId = c.Int(),
                        MaterialId = c.Int(),
                        CriterionId = c.Int(nullable: false),
                        IsDynamic = c.Boolean(nullable: false),
                        IsDetailed = c.Boolean(nullable: false),
                        UnitId = c.Int(),
                        CertificateId = c.Int(),
                        Level = c.Int(),
                        Contrafactor = c.Decimal(precision: 18, scale: 2),
                        AQL = c.Int(),
                        ProductionEquipmentName = c.String(),
                        NominalSize = c.Decimal(precision: 18, scale: 2),
                        MaxSize = c.Decimal(precision: 18, scale: 2),
                        MinSize = c.Decimal(precision: 18, scale: 2),
                        PurchasingControl = c.Boolean(nullable: false),
                        ProductionControl = c.Boolean(nullable: false),
                        Description = c.String(),
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
                        ProductionEquipment_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Certificates", t => t.CertificateId)
                .ForeignKey("dbo.Criteria", t => t.CriterionId, cascadeDelete: true)
                .ForeignKey("dbo.Units", t => t.UnitId)
                .ForeignKey("dbo.Materials", t => t.MaterialId)
                .ForeignKey("dbo.QualityPlans", t => t.QualityPlanId)
                .ForeignKey("dbo.ProductionEquipments", t => t.ProductionEquipment_Id)
                .Index(t => t.QualityPlanId)
                .Index(t => t.MaterialId)
                .Index(t => t.CriterionId)
                .Index(t => t.UnitId)
                .Index(t => t.CertificateId)
                .Index(t => t.ProductionEquipment_Id);
            
            CreateTable(
                "dbo.Certificates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false, maxLength: 4000),
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
                        Name = c.String(),
                        Level = c.Int(),
                        CertificateId = c.Int(),
                        Contrafactor = c.Decimal(precision: 18, scale: 2),
                        AQL = c.Int(),
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
                        Description = c.String(),
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
                        UserName = c.String(nullable: false),
                        ContactNumber = c.String(),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        ContactType = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                        CompanyId = c.Int(),
                        DepartmentId = c.Int(),
                        PositionId = c.Int(),
                        Profile = c.String(nullable: false),
                        FilePath = c.String(nullable: false),
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
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.Positions", t => t.PositionId)
                .Index(t => t.CompanyId)
                .Index(t => t.DepartmentId)
                .Index(t => t.PositionId);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        DepartmantId = c.Int(),
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
                        Department_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.Department_Id)
                .Index(t => t.Department_Id);
            
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LanguageId = c.Int(),
                        Name = c.String(nullable: false),
                        Factor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
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
                        Name = c.String(),
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
                        Name = c.String(nullable: false),
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
                        Name = c.String(nullable: false),
                        Index = c.Int(nullable: false),
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
                        CompanyId = c.Int(),
                        FacilityId = c.Int(),
                        MaterialId = c.Int(),
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
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .ForeignKey("dbo.Facilities", t => t.FacilityId)
                .ForeignKey("dbo.Materials", t => t.MaterialId)
                .Index(t => t.CompanyId)
                .Index(t => t.FacilityId)
                .Index(t => t.MaterialId);
            
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
            DropForeignKey("dbo.ProductionEquipments", "FacilityId", "dbo.Facilities");
            DropForeignKey("dbo.ProductionEquipments", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.ChangeQualityPlans", "ProductionEquipment_Id", "dbo.ProductionEquipments");
            DropForeignKey("dbo.QualityPlans", "MaterialId", "dbo.Materials");
            DropForeignKey("dbo.QualityPlans", "FacilityId", "dbo.Facilities");
            DropForeignKey("dbo.QualityPlans", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.ChangeQualityPlans", "QualityPlanId", "dbo.QualityPlans");
            DropForeignKey("dbo.ChangeQualityPlans", "MaterialId", "dbo.Materials");
            DropForeignKey("dbo.UserGroups", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.Criteria", "UserGroupId", "dbo.UserGroups");
            DropForeignKey("dbo.Units", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.ProductionEquipments", "Language_Id", "dbo.Languages");
            DropForeignKey("dbo.Criteria", "UnitId", "dbo.Units");
            DropForeignKey("dbo.ChangeQualityPlans", "UnitId", "dbo.Units");
            DropForeignKey("dbo.SystemUsers", "PositionId", "dbo.Positions");
            DropForeignKey("dbo.Positions", "Department_Id", "dbo.Departments");
            DropForeignKey("dbo.SystemUsers", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Criteria", "SystemUserId", "dbo.SystemUsers");
            DropForeignKey("dbo.SystemUsers", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Criteria", "ProductionEquipmentId", "dbo.ProductionEquipments");
            DropForeignKey("dbo.ChangeQualityPlans", "CriterionId", "dbo.Criteria");
            DropForeignKey("dbo.Criteria", "CertificateId", "dbo.Certificates");
            DropForeignKey("dbo.ChangeQualityPlans", "CertificateId", "dbo.Certificates");
            DropForeignKey("dbo.Departments", "FacilityId", "dbo.Facilities");
            DropForeignKey("dbo.Facilities", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Departments", "CompanyId", "dbo.Companies");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.QualityPlans", new[] { "MaterialId" });
            DropIndex("dbo.QualityPlans", new[] { "FacilityId" });
            DropIndex("dbo.QualityPlans", new[] { "CompanyId" });
            DropIndex("dbo.UserGroups", new[] { "LanguageId" });
            DropIndex("dbo.Units", new[] { "LanguageId" });
            DropIndex("dbo.Positions", new[] { "Department_Id" });
            DropIndex("dbo.SystemUsers", new[] { "PositionId" });
            DropIndex("dbo.SystemUsers", new[] { "DepartmentId" });
            DropIndex("dbo.SystemUsers", new[] { "CompanyId" });
            DropIndex("dbo.Criteria", new[] { "UserGroupId" });
            DropIndex("dbo.Criteria", new[] { "SystemUserId" });
            DropIndex("dbo.Criteria", new[] { "ProductionEquipmentId" });
            DropIndex("dbo.Criteria", new[] { "UnitId" });
            DropIndex("dbo.Criteria", new[] { "CertificateId" });
            DropIndex("dbo.ChangeQualityPlans", new[] { "ProductionEquipment_Id" });
            DropIndex("dbo.ChangeQualityPlans", new[] { "CertificateId" });
            DropIndex("dbo.ChangeQualityPlans", new[] { "UnitId" });
            DropIndex("dbo.ChangeQualityPlans", new[] { "CriterionId" });
            DropIndex("dbo.ChangeQualityPlans", new[] { "MaterialId" });
            DropIndex("dbo.ChangeQualityPlans", new[] { "QualityPlanId" });
            DropIndex("dbo.ProductionEquipments", new[] { "Language_Id" });
            DropIndex("dbo.ProductionEquipments", new[] { "FacilityId" });
            DropIndex("dbo.ProductionEquipments", new[] { "CompanyId" });
            DropIndex("dbo.Facilities", new[] { "CompanyId" });
            DropIndex("dbo.Departments", new[] { "FacilityId" });
            DropIndex("dbo.Departments", new[] { "CompanyId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.QualityPlans");
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
        }
    }
}
