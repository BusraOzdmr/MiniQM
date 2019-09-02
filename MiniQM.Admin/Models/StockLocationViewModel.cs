using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniQM.Admin.Models
{
    public class StockLocationViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Stok Yeri")]
        public string Name { get; set; }
        [Display(Name = "Firma")]
        public int CompanyId { get; set; }
        [Display(Name = "Firma")]
        public string CompanyName { get; set; }
        [Display(Name = "Tesis")]
        public int FacilityId { get; set; }
        [Display(Name = "Tesis")]
        public string FacilityName { get; set; }
        [Display(Name = "Depo")]
        public string Warehouse { get; set; }
        [Display(Name = "Açıklama")]
        public string Description { get; set; }

        [Display(Name = "Aktif mi?")]
        public bool IsActive { get; set; }
    }
}