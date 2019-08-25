using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Model
{
    public class Department:BaseEntity
    {
        [Display(Name="Bölüm")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Firma")]
        
        public int? CompanyId { get; set; }
        public string CompanyName { get; set; }
        public virtual Company Company { get; set; }
        [Display(Name = "Tesis")]
        
        public int? FacilityId { get; set; }
        public string FacilityName { get; set; }
        public virtual Facility Facility { get; set; }

        public virtual ICollection<Position> Positions { get; set; }
        public virtual ICollection<SystemUser> SystemUsers { get; set; }
    }
}
