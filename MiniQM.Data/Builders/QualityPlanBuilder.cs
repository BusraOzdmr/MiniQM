using MiniQM.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Data.Builders
{
    public class QualityPlanBuilder
    {
        public QualityPlanBuilder(EntityTypeConfiguration<QualityPlan> builder)
        {
            builder.Property(b => b.Description).HasMaxLength(4000);
            builder.HasRequired(a => a.Company).WithMany(b => b.QualityPlans).HasForeignKey(a => a.CompanyId);
            builder.HasOptional(a => a.Facility).WithMany(b => b.QualityPlans).HasForeignKey(a => a.FacilityId);
            builder.HasRequired(a => a.Material).WithMany(b => b.QualityPlans).HasForeignKey(a => a.MaterialId);
        }
    }
}
