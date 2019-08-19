using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Model
{
    public enum UnitCategory
    {
        [Display(Name="Sayı")]
        Count = 0,
        [Display(Name = "Ağırlık")]
        Weight = 1,
        [Display(Name = "Uzunluk")]
        Length =2
    }
}
