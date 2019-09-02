using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Model
{
    public class OrderType:BaseEntity
    {
        public string Name { get; set; }
        public string TypeCode { get; set;  } //Tip kodu
        public string Description { get; set; }
        public virtual ICollection<MaterialInput> MaterialInputs { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
