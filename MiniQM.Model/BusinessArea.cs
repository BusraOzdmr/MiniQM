using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Model
{
    public class BusinessArea : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? MainAreaId { get; set; }
        public virtual BusinessArea MainArea { get; set; }
        public virtual ICollection<BusinessArea> ChildAreas { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; }

    }
}
