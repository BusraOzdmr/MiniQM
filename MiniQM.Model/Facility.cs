﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Model
{
    public class Facility:BaseEntity //Tesis
    {
        [Display(Name = "Ad")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Bağlı Olduğu Firma")]
        [Required]
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
    }
}
