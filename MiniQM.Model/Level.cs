using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Model
{
    public enum Level
    {
        [Display(Name = "Düşük")]
        [Required]
        Reduced = 0,
        [Display(Name = "Normal")]
        [Required]
        Normal = 1,
        [Display(Name = "Yüksek")]
        [Required]
        Intensive = 2

    }
}
