using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Model
{
    public class Position:BaseEntity
    {
        [Display(Name="Pozisyon")]
        [Required]
        public string Name { get; set;}        
        public int DepartmentId { get; set; }        
        public virtual Department Department { get; set; }
        public virtual ICollection<SystemUser> SystemUsers { get; set; }

    }
}
