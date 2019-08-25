using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Model
{
    public class Certificate:BaseEntity
    {
        [Display(Name="Sertifika Adı")]
        [Required]
        public string Name { get; set; }
        [Display(Name="Açıklama")]
        [Required]
        [MaxLength(4000)]
        public string Description { get; set; }
        public virtual ICollection<ChangeQualityPlan> ChangeQualityPlans { get; set; }
        public virtual ICollection<Criterion> Criterions { get; set; }
    }
}
