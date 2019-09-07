using MiniQM.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Data.Builders
{
    class OrderTypeBuilder
    {
        public OrderTypeBuilder(EntityTypeConfiguration<OrderType> builder)
        {
            builder.Property(b => b.Name).HasMaxLength(100).IsRequired();
            builder.Property(b => b.TypeCode).HasMaxLength(100).IsRequired();
            builder.Property(b => b.Description).HasMaxLength(4000);
        }
    }
}
