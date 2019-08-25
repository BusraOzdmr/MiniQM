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
        [Display(Name = "Ad")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Bağlı Olduğu Firma")]
        
        public int? CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public virtual ICollection<QualityPlan> QualityPlans { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<ProductionEquipment> ProductionEquipments { get; set; }
    }
}
