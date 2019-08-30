using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniQM.Admin.Models
{
    public class MaterialViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Ad")]
        [Required]
        public string Name { get; set; }
        [Display(Name="Aktif mi?")]
        public bool IsActive { get; set; }
        

    }
}