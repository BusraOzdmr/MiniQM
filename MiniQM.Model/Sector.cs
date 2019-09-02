using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Model
{
    public class Sector:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}
