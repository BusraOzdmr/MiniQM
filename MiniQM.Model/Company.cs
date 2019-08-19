using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Model
{
    public class Company:BaseEntity //Firma
    {
        [Display(Name = "Ad")]
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Facility> Facilities { get; set; }

    }
}
