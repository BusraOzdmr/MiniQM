using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniQM.Admin.Models
{
    public class FacilityViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Ad")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Bağlı Olduğu Firma")]
        
        public int? CompanyId { get; set; }

        [Display(Name = "Bağlı Olduğu Firma")]
        public string CompanyName { get; set; }
    }
}