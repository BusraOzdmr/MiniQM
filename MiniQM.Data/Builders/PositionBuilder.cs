using MiniQM.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Data.Builders
{
    public class PositionBuilder
    {
        public PositionBuilder(EntityTypeConfiguration<Position> builder)
        {
            builder.Property(b => b.Name).HasMaxLength(100).IsRequired();
            builder.HasRequired(a => a.Department).WithMany(b => b.Positions).HasForeignKey(a => a.DepartmentId);
        }
    }
}
