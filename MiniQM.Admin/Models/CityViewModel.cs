using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniQM.Admin.Models
{
    public class CityViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Şehir")]
        public string Name { get; set; }
        
        public int CountryId { get; set; }
        [Display(Name = "Ülke")]
        public string CountryName { get; set; }
        [Display(Name = "Aktif mi?")]
        public bool IsActive { get; set; }
    }
}