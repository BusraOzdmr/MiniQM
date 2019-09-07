using MiniQM.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Data.Builders
{
    public class PurchasingDepartmentBuilder
    {
        public PurchasingDepartmentBuilder(EntityTypeConfiguration<PurchasingDepartment> builder)
        {
            builder.Property(b => b.Name).HasMaxLength(100).IsRequired();
            builder.HasRequired(a => a.Company).WithMany(b => b.PurchasingDepartments).HasForeignKey(a => a.CompanyId);
            
        }
    }
}
