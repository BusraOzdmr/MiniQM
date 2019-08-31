using MiniQM.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniQM.Admin.Models
{
    public class UnitViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Dil")]
        public int? LanguageId { get; set; }

        [Display(Name = "Dil")]
        public string LanguageCode { get; set; }
        
        [Display(Name = "Birim")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Faktör")]
        public decimal? Factor { get; set; }
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        [Display(Name = "Kategori")]
        public UnitCategory UnitCategory { get; set; }
        [Display(Name = "Aktif mi?")]
        public bool IsActive { get; set; }
    }
}