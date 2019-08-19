using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Model
{
    public class Facility:BaseEntity //Tesis
    {
        public string Name { get; set; }
        public Company Company { get; set; }
    }
}
