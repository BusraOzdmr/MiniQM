using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Model
{
    public enum IsProcess            
    {
        [Display(Name = "Süreç Değil")]
        NotProcess = 0,
        [Display(Name = "Süreç")]
        Process = 1,
        [Display(Name = "Tümü")]
        All = 2
    }
}
