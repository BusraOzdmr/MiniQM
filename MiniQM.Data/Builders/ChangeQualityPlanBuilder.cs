using MiniQM.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Data.Builders
{
    class ChangeQualityPlanBuilder
    {
        public ChangeQualityPlanBuilder(EntityTypeConfiguration<ChangeQualityPlan> builder)
        {
            builder.Property(b => b.Description).HasMaxLength(4000);
            builder.HasRequired(a => a.QualityPlan).WithMany(b => b.ChangeQualityPlans).HasForeignKey(a => a.QualityPlanId);
            builder.HasOptional(a => a.Material).WithMany(b => b.ChangeQualityPlans).HasForeignKey(a => a.MaterialId);
            builder.HasOptional(a => a.Criterion).WithMany(b => b.ChangeQualityPlans).HasForeignKey(a => a.CriterionId);
            builder.HasOptional(a => a.Unit).WithMany(b => b.ChangeQualityPlans).HasForeignKey(a => a.UnitId);
            builder.HasOptional(a => a.Criterion).WithMany(b => b.ChangeQualityPlans).HasForeignKey(a => a.CriterionId);
            builder.HasOptional(a => a.Certificate).WithMany(b => b.ChangeQualityPlans).HasForeignKey(a => a.CertificateId);
            builder.HasOptional(a => a.Unit).WithMany(b => b.ChangeQualityPlans).HasForeignKey(a => a.UnitId);
            builder.HasOptional(a => a.ProductionEquipment).WithMany(b => b.ChangeQualityPlans).HasForeignKey(a => a.ProductionEquipmentId);
        }
    }
}
