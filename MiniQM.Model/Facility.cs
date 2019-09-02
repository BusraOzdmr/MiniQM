using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Model
{
    public class Facility:BaseEntity //Tesis
    {
        
        public string Name { get; set; }
               
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public virtual ICollection<QualityPlan> QualityPlans { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<ProductionEquipment> ProductionEquipments { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<StockLocation> StockLocations { get; set; }
    }
}
