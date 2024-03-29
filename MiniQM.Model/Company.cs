﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Model
{
    public class Company:BaseEntity //Firma
    {
        [Display(Name = "Ad")]
        [Required]
        public string Name { get; set; }
        public virtual ICollection<QualityPlan> QualityPlans { get; set; }
        public virtual ICollection<Facility> Facilities { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<ProductionEquipment> ProductionEquipments { get; set; }
        public virtual ICollection<SystemUser> SystemUsers { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<PurchasingDepartment> PurchasingDepartments { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; }
        public virtual ICollection<StockLocation> StockLocations { get; set; }
    }
}
