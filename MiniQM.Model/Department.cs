using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Model
{
    public class Department
    {
        [Display(Name="Bölüm")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Firma")]
        [Required]
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        [Display(Name = "Tesis")]
        [Required]
        public int FacilityId { get; set; }
        public Facility Facility { get; set; }

        public virtual ICollection<Position> Positions { get; set; }
    }
}
