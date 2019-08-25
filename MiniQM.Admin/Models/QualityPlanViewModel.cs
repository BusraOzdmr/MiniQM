using MiniQM.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniQM.Admin.Models
{
    public class QualityPlanViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Firma")]
        [Required]
        public int CompanyId { get; set; }
        [Display(Name = "Firma")]
        public string CompanyName { get; set; }

        [Display(Name = "Tesis")]
        [Required]
        public int FacilityId { get; set; }
        [Display(Name = "Tesis")]
        public string FacilityName { get; set; }

        [Display(Name = "Malzeme İndexi")]
        [Required]
        public int MaterialIndex { get; set; }
        [Display(Name = "Malzeme")]
        [Required]
        public int MaterialId { get; set; }
        [Display(Name = "Malzeme")]
        public string MaterialName { get; set; }

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
    }
}