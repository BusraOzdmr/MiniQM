using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniQM.Admin.Models
{
    public class BusinessAreaViewModel
    {
        public int Id { get; set; }
        [Display(Name="İş Alanı")]
        public string Name { get; set; }
        [Display(Name = "Üst İş Alanı")]
        public int? MainAreaId { get; set; }
        [Display(Name = "Üst İş Alanı")]
        public string MainAreaName { get; set; }
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        [Display(Name = "Aktif mi?")]
        public bool IsActive { get; set; }
    }
}