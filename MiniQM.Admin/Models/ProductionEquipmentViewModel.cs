using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniQM.Admin.Models
{
    public class ProductionEquipmentViewModel
    {
        public int Id { get; set; }
        [Display(Name="Dil")]
        public int? LanguageId { get; set; }
        [Display(Name = "Dil")]
        public string LanguageCode { get; set; }
        [Display(Name = "Firma")]
        
        public int? CompanyId { get; set; }
        [Display(Name = "Firma")]
        public string CompanyName { get; set; }
        [Display(Name = "Tesis")]
        
        public int? FacilityId { get; set; }
        [Display(Name = "Tesis")]
        public string FacilityName { get; set; }
        [Display(Name = "Araç ve Gereç")]
        public string Name { get; set; }
        [Display(Name = "Açıklama")]
        [MaxLength(4000)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Display(Name = "Aktif mi?")]
        public bool IsActive { get; set; }
    }
}