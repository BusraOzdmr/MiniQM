using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Model
{
    public class Unit:BaseEntity
    {
        [Display(Name="Dil")]
        public int? LanguageId { get; set; }
        public virtual Language Language { get; set; }
        [Display(Name = "Birim")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Faktör")]
        public decimal? Factor { get; set; }
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        [Display(Name = "Kategori")]
        public UnitCategory UnitCategory { get; set; }
        public virtual ICollection<Criterion> Criterions { get; set; }
        public virtual ICollection<ChangeQualityPlan> ChangeQualityPlans { get; set; }

    }
}
