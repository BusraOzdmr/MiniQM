using MiniQM.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Data.Builders
{
    public class OrderBuilder
    {
        public OrderBuilder(EntityTypeConfiguration<Order> builder)
        {
            builder.Property(b => b.Name).HasMaxLength(100).IsRequired();
            builder.HasOptional(a => a.Company).WithMany(b => b.Orders).HasForeignKey(a => a.CompanyId);
            builder.HasOptional(a => a.Facility).WithMany(b => b.Orders).HasForeignKey(a => a.FacilityId);
            builder.HasRequired(a => a.BusinessArea).WithMany(b => b.Orders).HasForeignKey(a => a.BusinessAreaId);
            builder.HasRequired(a => a.PurchasingDepartment).WithMany(b => b.Orders).HasForeignKey(a => a.PurchasingDepartmentId);
            builder.HasRequired(a => a.OrderType).WithMany(b => b.Orders).HasForeignKey(a => a.OrderTypeId);
            builder.HasRequired(a => a.Supplier).WithMany(b => b.Orders).HasForeignKey(a => a.SupplierId);
        }
    }
}
