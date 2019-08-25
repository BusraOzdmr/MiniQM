using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniQM.Admin.Models
{
    public class LanguageViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Dil")]
        public string Name { get; set; }
        [Display(Name = "Dil Kodu")]
        public string Code { get; set; }
    }
}