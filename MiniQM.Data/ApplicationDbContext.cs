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
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new CompanyBuilder(modelBuilder.Entity<Company>());
            new FacilityBuilder(modelBuilder.Entity<Facility>());
            new DepartmentBuilder(modelBuilder.Entity<Department>());
            new QualityPlanBuilder(modelBuilder.Entity<QualityPlan>());
            new MaterialBuilder(modelBuilder.Entity<Material>());
            new PositionBuilder(modelBuilder.Entity<Position>());
        }

        
    }
}
