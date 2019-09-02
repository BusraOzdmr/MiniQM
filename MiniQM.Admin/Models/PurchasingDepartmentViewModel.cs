using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniQM.Admin.Models
{
    public class PurchasingDepartmentViewModel
    {
        public int Id { get; set; }
        [Display(Name="Satın Alma Bölümü")]
        public string Name { get; set; }
        [Display(Name = "Firma")]
        public int CompanyId { get; set; }
        [Display(Name = "Firma")]
        public string CompanyName { get; set; }
        [Display(Name = "Aktif mi?")]
        public bool IsActive { get; set; }

    }
}