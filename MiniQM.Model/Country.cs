using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Model
{
    public class Country:BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}
