using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniQM.Admin.Models
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Bölüm")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Firma")]
        
        public int? CompanyId { get; set; }
        [Display(Name = "Firma")]
        public string CompanyName { get; set; }
        [Display(Name = "Tesis")]
        
        public int? FacilityId { get; set; }
        [Display(Name = "Tesis")]
        public string FacilityName { get; set; }
    }
}