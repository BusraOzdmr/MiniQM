using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniQM.Admin.Models
{
    public class SupplierViewModel
    {
        public int Id { get; set; }
        [Display(Name="Tedarikçi")]
        public string Name { get; set; }
        [Display(Name = "Firma")]
        public int CompanyId { get; set; }
        [Display(Name = "Firma")]
        public string CompanyName { get; set; }
        [Display(Name = "İş Alanı")]
        public int BusinessAreaId { get; set; }
        [Display(Name = "İş Alanı")]
        public string BusinessAreaName { get; set; }
        [Display(Name = "Sektör")]
        public int SectorId { get; set; }
        [Display(Name = "Sektör")]
        public string SectorName { get; set; }
        [Display(Name = "Ülke")]
        public int? CountryId { get; set; }
        [Display(Name = "Ülke")]
        public string CountryName { get; set; }
        [Display(Name = "Şehir")]
        public int? CityId { get; set; }
        [Display(Name = "Şehir")]
        public string CityName { get; set; }
        [Display(Name = "Aktif mi?")]
        public bool IsActive { get; set; }
    }
}