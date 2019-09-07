using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniQM.Model;

namespace MiniQM.Data.Builders
{
    public class UnitBuilder
    {
        public UnitBuilder(EntityTypeConfiguration<Unit> builder)
        {
            builder.Property(b => b.Name).HasMaxLength(100).IsRequired();
            builder.Property(b => b.Description).HasMaxLength(4000);
            builder.HasOptional(a => a.Language).WithMany(b => b.Units).HasForeignKey(a => a.LanguageId);
        }
    }
}
