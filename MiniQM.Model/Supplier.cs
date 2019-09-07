using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Model
{
    public class Supplier: BaseEntity
    {
        public int? CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public string Name { get; set; }
        public int? BusinessAreaId { get; set; }
        public virtual BusinessArea BusinessArea { get; set; }
        public int SectorId { get; set; }
        public virtual Sector Sector { get; set; }
        public int? CountryId { get; set; }
        public virtual Country Country { get; set; }
        public int? CityId { get; set; }
        public virtual City City { get; set; }
        public virtual ICollection<MaterialInput> MaterialInputs { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
