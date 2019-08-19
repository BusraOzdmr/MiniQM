using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Model
{
    public class Language:BaseEntity
    {
        [Display(Name = "Dil")]
        public string Name { get; set; }
        [Display(Name = "Dil Kodu")]
        public string Code { get; set; }
    }
}
