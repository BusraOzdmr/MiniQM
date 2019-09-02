using MiniQM.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniQM.Admin.Models
{
    public class MaterialInputViewModel
    {
        public int Id { get; set; }
        [Display(Name="Sipariş Tipi")]
        public int OrderTypeId { get; set; }
        [Display(Name = "Sipariş Tipi")]
        public string OrderTypeName { get; set; }
        [Display(Name = "Sipariş")]
        public int OrderId { get; set; }
        [Display(Name = "Sipariş")]
        public string OrderName { get; set; }
        [Display(Name = "Kalem")]
        public decimal Cost { get; set; } // Kalem
        [Display(Name = "Malzeme")]
        public int MaterialId { get; set; }
        [Display(Name = "Malzeme")]
        public string MaterialName { get; set; }
        [Display(Name = "Giriş Miktarı")]
        public decimal InputAmount { get; set; } //Giriş miktarı
        [Display(Name = "Numune Miktarı")]
        public decimal SampleAmount { get; set; } // numune miktarı
        [Display(Name = "Nitelik")]
        public MaterialQuality MaterialQuality { get; set; }
        [Display(Name = "Geri Gönderilen")]
        public decimal Returned { get; set; } //geri gönderilen
        [Display(Name = "Tedarikçi")]
        public int SupplierId { get; set; }
        [Display(Name = "Tedarikçi")]
        public string SupplierName { get; set; } //Tedarikçi
        [Display(Name = "Stok Yeri")]
        public int StockLocationId { get; set; }
        [Display(Name = "Stok Yeri")]
        public string StockLocationName { get; set; }
        [Display(Name = "Kontrol Edildi")]
        public bool Checked { get; set; }
        [Display(Name = "Kalite Kontrol Statüsü")]
        public QualityControlStatus QualityControlStatus { get; set; }
        [Display(Name = "Aktif mi?")]
        public bool IsActive { get; set; }
    }
}