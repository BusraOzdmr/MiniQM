using MiniQM.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Data.Builders
{
    public class SupplierBuilder
    {
        public SupplierBuilder(EntityTypeConfiguration<Supplier> builder)
        {
            builder.Property(b => b.Name).HasMaxLength(100).IsRequired();
            
            builder.HasOptional(a => a.Company).WithMany(b => b.Suppliers).HasForeignKey(a => a.CompanyId);
            builder.HasOptional(a => a.BusinessArea).WithMany(b => b.Suppliers).HasForeignKey(a => a.BusinessAreaId);
            builder.HasRequired(a => a.Sector).WithMany(b => b.Suppliers).HasForeignKey(a => a.SectorId);
            builder.HasOptional(a => a.Country).WithMany(b => b.Suppliers).HasForeignKey(a => a.CountryId);
            builder.HasOptional(a => a.City).WithMany(b => b.Suppliers).HasForeignKey(a => a.CityId);
        }
    }
}
