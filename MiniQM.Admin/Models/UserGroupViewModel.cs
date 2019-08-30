using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniQM.Admin.Models
{
    public class UserGroupViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Kullanıcı Grubu")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Açıklama Dili")]
        public int? LanguageId { get; set; }
        [Display(Name = "Açıklama Dili")]
        public string LanguageCode { get; set; }
        

        [Display(Name = "Grup Açıklaması")]
        [MaxLength(4000)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Aktif Mi?")]
        public bool IsActive { get; set; }
    }
}