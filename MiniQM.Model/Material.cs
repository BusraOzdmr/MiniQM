using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Model
{
    public class Material:BaseEntity //Malzeme
    {
        [Display(Name = "Ad")]
        [Required]
        public string Name { get; set; }
        
        public virtual ICollection<QualityPlan> QualityPlans { get; set; }
        public virtual ICollection<ChangeQualityPlan> ChangeQualityPlans { get; set; }
        public virtual ICollection<MaterialInput> MaterialInputs { get; set; }
    }
}
