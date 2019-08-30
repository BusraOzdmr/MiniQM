using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Model
{
    public class QualityPlan:BaseEntity // Kalite Planı
    {        
 
        
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
   
        
        public int? FacilityId { get; set; }
        public virtual Facility Facility { get; set; }
  
        
        public int MaterialId{ get; set; }
        public virtual Material Material { get; set; }

        
        [Display(Name = "Açıklama")]
        [MaxLength(4000)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Başlangıç Tarihi")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [Display(Name = "Bitiş Tarihi")]
        [DataType(DataType.Date)]
        public DateTime? ClosedDate { get; set; }

        [Display(Name = "Süreç mi?")]
        public IsProcess? IsProcess { get; set; }
        public virtual ICollection<ChangeQualityPlan> ChangeQualityPlans { get; set; }

    }
}
