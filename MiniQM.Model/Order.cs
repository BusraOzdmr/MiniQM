using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Model
{
    public class Order : BaseEntity
    {
        public string Name { get; set; }
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public int FacilityId { get; set; }
        public virtual Facility Facility { get; set; }
        public int BusinessAreaId { get; set; }
        public virtual BusinessArea BusinessArea { get; set; }
        public int PurchasingDepartmentId { get; set; }
        public PurchasingDepartment PurchasingDepartment { get; set; }
        public int OrderTypeId { get; set; }
        public OrderType OrderType { get; set; }
        public DateTime OrderDate { get; set; }
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
        public decimal Gross { get; set; } //Brüt
        public decimal Discount { get; set; } //İndirimler
        public decimal NetCost { get; set; } //Net
        public virtual ICollection<MaterialInput> MaterialInputs { get; set; }

    }
}
