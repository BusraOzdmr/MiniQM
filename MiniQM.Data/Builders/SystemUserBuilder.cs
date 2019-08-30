using MiniQM.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Data.Builders
{
    class SystemUserBuilder
    {
        public SystemUserBuilder(EntityTypeConfiguration<SystemUser> builder)
        {
            builder.Property(b => b.UserName).HasMaxLength(100).IsRequired();
            builder.Property(b => b.ContactNumber).HasMaxLength(15);
            builder.Property(b => b.Name).HasMaxLength(100).IsRequired();
            builder.Property(b => b.Surname).HasMaxLength(100).IsRequired();
            builder.Property(b => b.Email).HasMaxLength(100);
            builder.Property(b => b.Profile).HasMaxLength(500);
            builder.Property(b => b.FilePath).HasMaxLength(500);
            builder.HasRequired(a => a.Company).WithMany(b => b.SystemUsers).HasForeignKey(a => a.CompanyId);
            builder.HasRequired(a => a.Department).WithMany(b => b.SystemUsers).HasForeignKey(a => a.DepartmentId);
            builder.HasOptional(a => a.Position).WithMany(b => b.SystemUsers).HasForeignKey(a => a.PositionId);
        }
    }
}
