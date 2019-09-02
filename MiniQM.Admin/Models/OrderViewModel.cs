using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniQM.Admin.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        [Display(Name="Sipariş")]
        public string Name { get; set; }
        [Display(Name = "Firma")]
        public int CompanyId { get; set; }
        [Display(Name = "Firma")]
        public string CompanyName { get; set; }
        [Display(Name = "Tesis")]
        public int FacilityId { get; set; }
        [Display(Name = "Tesis")]
        public string FacilityName { get; set; }
        [Display(Name = "İş Alanı")]
        public int BusinessAreaId { get; set; }
        [Display(Name = "İş Alanı")]
        public string BusinessAreaName { get; set; }
        [Display(Name = "Satın Alma Bölümü")]
        public int PurchasingDepartmentId { get; set; }
        [Display(Name = "Satın Alma Bölümü")]
        public string PurchasingDepartmentName { get; set; }
        [Display(Name = "Sipariş Tipi")]
        public int OrderTypeId { get; set; }
        [Display(Name = "Sipariş Tipi")]
        public string OrderTypeName { get; set; }
        [Display(Name = "Sipariş Tarihi")]
        public DateTime OrderDate { get; set; }
        [Display(Name = "Tedarikçi")]
        public int SupplierId { get; set; }
        [Display(Name = "Tedarikçi")]
        public string SupplierName { get; set; }
        [Display(Name = "Brüt")]
        public decimal Gross { get; set; } //Brüt
        [Display(Name = "İndirimler")]
        public decimal Discount { get; set; } //İndirimler
        [Display(Name = "Net")]
        public decimal NetCost { get; set; } //Net
        [Display(Name = "Aktif mi?")]
        public bool IsActive { get; set; }

    }
}