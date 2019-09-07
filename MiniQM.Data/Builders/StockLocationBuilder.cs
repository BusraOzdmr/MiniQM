using MiniQM.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Data.Builders
{
    public class StockLocationBuilder
    {
        public StockLocationBuilder(EntityTypeConfiguration<StockLocation> builder)
        {
            builder.Property(b => b.Name).HasMaxLength(100).IsRequired();
            builder.Property(b => b.Warehouse).HasMaxLength(100).IsRequired();
            builder.Property(b => b.Description).HasMaxLength(4000);
            builder.HasOptional(a => a.Company).WithMany(b => b.StockLocations).HasForeignKey(a => a.CompanyId);
            builder.HasOptional(a => a.Facility).WithMany(b => b.StockLocations).HasForeignKey(a => a.FacilityId);
        }
    }
}
