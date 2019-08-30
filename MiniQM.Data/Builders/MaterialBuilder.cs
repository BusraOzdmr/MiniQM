using MiniQM.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Data.Builders
{
    class MaterialBuilder
    {
        public MaterialBuilder(EntityTypeConfiguration<Material> builder)
        {
            builder.Property(b => b.Name).HasMaxLength(500).IsRequired();
            
            
        }
    }
}
