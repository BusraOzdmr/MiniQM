using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Model
{
    public class Material:BaseEntity //Malzeme
    {
        [Display(Name = "Ad")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "İndex")]
        [Required]
        public int Index { get; set; }
    }
}
