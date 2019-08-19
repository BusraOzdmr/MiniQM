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
        Process = 1,
        All = 2
    }
}
