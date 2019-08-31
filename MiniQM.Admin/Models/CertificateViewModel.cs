using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniQM.Admin.Models
{
    public class CertificateViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Sertifika Adı")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Açıklama")]
        [DataType(DataType.MultilineText)]
        [MaxLength(4000)]
        public string Description { get; set; }
        [Display(Name = "Açıklama")]
        public bool IsActive { get; set; }

    }
}