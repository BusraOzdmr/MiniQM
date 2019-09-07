using MiniQM.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Data.Builders
{
    public class CriterionBuilder
    {
        public CriterionBuilder(EntityTypeConfiguration<Criterion> builder)
        {
            builder.Property(b => b.Name).HasMaxLength(100).IsRequired();
            builder.Property(b => b.Description).HasMaxLength(4000);
            builder.HasRequired(a => a.Certificate).WithMany(b => b.Criterions).HasForeignKey(a => a.CertificateId);
            builder.HasOptional(a => a.Unit).WithMany(b => b.Criterions).HasForeignKey(a => a.UnitId);
            builder.HasOptional(a => a.ProductionEquipment).WithMany(b => b.Criterions).HasForeignKey(a => a.ProductionEquipmentId);
            builder.HasOptional(a => a.SystemUser).WithMany(b => b.Criterions).HasForeignKey(a => a.SystemUserId);
            builder.HasOptional(a => a.UserGroup).WithMany(b => b.Criterions).HasForeignKey(a => a.UserGroupId);
        }
    }
}
