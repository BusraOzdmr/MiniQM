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
        [Display(Name = "Firma")]
        [Required]
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        [Display(Name = "Tesis")]
        [Required]
        public int FacilityId { get; set; }
        public Facility Facility { get; set; }

        [Display(Name = "Malzeme İndexi")]
        [Required]
        public int MaterialIndex { get; set; }
        [Display(Name = "Malzeme No")]
        [Required]
        public int MaterialId{ get; set; }
        public Material Material { get; set; }

        [Display(Name = "Açıklama")]
        [MaxLength(4000)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Tarih")]
        public DateTime OperationDate { get; set; } //İşlemTarihi

        [Display(Name = "Süreç mi?")]
        public IsProcess? IsProcess { get; set; }


    }
}
