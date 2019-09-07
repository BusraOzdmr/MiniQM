using MiniQM.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Data.Builders
{
    public class MaterialInputBuilder
    {
        public MaterialInputBuilder(EntityTypeConfiguration<MaterialInput> builder)
        {
            builder.HasOptional(a => a.Order).WithMany(b => b.MaterialInputs).HasForeignKey(a => a.OrderId);
            builder.HasOptional(a => a.OrderType).WithMany(b => b.MaterialInputs).HasForeignKey(a => a.OrderTypeId);
            builder.HasRequired(a => a.Material).WithMany(b => b.MaterialInputs).HasForeignKey(a => a.MaterialId);
            builder.HasRequired(a => a.Supplier).WithMany(b => b.MaterialInputs).HasForeignKey(a => a.SupplierId);
            builder.HasRequired(a => a.StockLocation).WithMany(b => b.MaterialInputs).HasForeignKey(a => a.StockLocationId);
        }
    }
}
