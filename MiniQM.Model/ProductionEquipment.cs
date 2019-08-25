using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Model
{
    public class ProductionEquipment:BaseEntity
    {
        public int? LangugeId { get; set; }
        public virtual Language Language { get; set; }
        public int? CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public int? FacilityId { get; set; }
        public  virtual Facility Facility { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Criterion> Criterions { get; set; }
        public virtual ICollection<ChangeQualityPlan> ChangeQualityPlans { get; set; }

    }
}
