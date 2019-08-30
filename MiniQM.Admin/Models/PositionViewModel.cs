using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniQM.Admin.Models
{
    public class PositionViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Pozisyon")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Bölüm")]
                
        public int DepartmentId { get; set; }
        [Display(Name = "Bölüm")]
        public string DepartmentName { get; set; }

        [Display(Name = "Aktif mi?")]
        public bool IsActive { get; set; }
    }
}