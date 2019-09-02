using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Model
{
    public enum  MaterialQuality
    {
        [Display(Name="İyi")]
        Good = 0,
        [Display(Name = "Kötü")]
        Bad = 1,
    }
}
