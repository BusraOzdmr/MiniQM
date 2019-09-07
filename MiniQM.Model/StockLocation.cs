using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Model
{
    public class StockLocation:BaseEntity
    {
        public string Name { get; set; }
        public int? CompanyId { get; set; }
        public Company Company { get; set; }
        public int? FacilityId { get; set; }
        public Facility Facility { get; set; }
        public string Warehouse { get; set; }
        public string Description { get; set; }
        public virtual ICollection<MaterialInput> MaterialInputs { get; set; }
    }
}
