using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Model
{
    public class QualityCertificateSamplePlan:BaseEntity
    {
        [Display(Name = "Firma")]
        [Required]
        public Company CompanyId { get; set; }
        [Display(Name = "Sertifika")]
        [Required]
        public string Certificate { get; set; }
        public Level Level { get; set; }
        [Display(Name = "Kabul Edilebilir Kalite Seviyesi")]
        [Required]
        public AQL AQL { get; set; }

        [Display(Name = "Contfactor")] //Q-factor
        [Required]
        public int Contfactor { get; set; }
    }
}
