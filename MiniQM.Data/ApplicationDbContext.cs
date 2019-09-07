using System;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using MiniQM.Data.Builders;
using MiniQM.Model;

namespace MiniQM.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }



        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Facility> Facilities { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<QualityPlan> QualityPlans { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<SystemUser> SystemUsers { get; set; }
        public virtual DbSet<UserGroup> UserGroups { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<ChangeQualityPlan> ChangeQualityPlans { get; set; }
        public virtual DbSet<Certificate> Certificates { get; set; }
        public virtual DbSet<Criterion> Criterions { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<ProductionEquipment> ProductionEquipments { get; set; }
        public virtual DbSet<MaterialInput> MaterialInputs { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderType> OrderTypes { get; set; }
        public virtual DbSet<PurchasingDepartment> PurchasingDepartments { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<BusinessArea> BusinessAreas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new CompanyBuilder(modelBuilder.Entity<Company>());
            new FacilityBuilder(modelBuilder.Entity<Facility>());
            new DepartmentBuilder(modelBuilder.Entity<Department>());
            new QualityPlanBuilder(modelBuilder.Entity<QualityPlan>());
            new MaterialBuilder(modelBuilder.Entity<Material>());
            new PositionBuilder(modelBuilder.Entity<Position>());
            new SystemUserBuilder(modelBuilder.Entity<SystemUser>());
            new UserGroupBuilder(modelBuilder.Entity<UserGroup>());
            new LanguageBuilder(modelBuilder.Entity<Language>());
            new ChangeQualityPlanBuilder(modelBuilder.Entity<ChangeQualityPlan>());
            new CertificateBuilder(modelBuilder.Entity<Certificate>());
            new UnitBuilder(modelBuilder.Entity<Unit>());
            new ProductionEquipmentBuilder(modelBuilder.Entity<ProductionEquipment>());
            new CriterionBuilder(modelBuilder.Entity<Criterion>());
            new MaterialInputBuilder(modelBuilder.Entity<MaterialInput>());
            new OrderBuilder(modelBuilder.Entity<Order>());
            new OrderTypeBuilder(modelBuilder.Entity<OrderType>());
            new PurchasingDepartmentBuilder(modelBuilder.Entity<PurchasingDepartment>());
            new SupplierBuilder(modelBuilder.Entity<Supplier>());
            new BusinessAreaBuilder(modelBuilder.Entity<BusinessArea>());

        }


        public System.Data.Entity.DbSet<MiniQM.Model.StockLocation> StockLocations { get; set; }

        public System.Data.Entity.DbSet<MiniQM.Model.City> Cities { get; set; }

        public System.Data.Entity.DbSet<MiniQM.Model.Country> Countries { get; set; }

        public System.Data.Entity.DbSet<MiniQM.Model.Sector> Sectors { get; set; }
    }
}
