using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniQM.Admin.Models
{
    public class OrderTypeViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Tip Kodu")]
        public string TypeCode { get; set; } //Tip kodu
        [Display(Name="Tip Adı")]
        public string Name { get; set; }
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        [Display(Name = "Aktif mi?")]
        public bool IsActive { get; set; }
    }
}