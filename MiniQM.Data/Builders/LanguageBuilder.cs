using MiniQM.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Data.Builders
{
    public class LanguageBuilder
    {
        public LanguageBuilder(EntityTypeConfiguration<Language> builder)
        {
            builder.Property(b => b.Name).HasMaxLength(100).IsRequired();
            
        }
    }
}
