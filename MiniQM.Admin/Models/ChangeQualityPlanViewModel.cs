using MiniQM.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniQM.Admin.Models
{
    public class ChangeQualityPlanViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Kalite Planı")]
        [Required]
        public int QualityPlanId { get; set; }
        public string QualityPlanName { get; set; }
        [Display(Name = "Malzeme İndeksi")]
        public int MaterialId { get; set; }
        [Display(Name = "Malzeme İndeksi")]
        public int MaterialIndex { get; set; }
        [Display(Name = "Kriter")]
        public int CriterionId { get; set; }
        [Display(Name = "Kriter")]
        public string CriterionName { get; set; }
        
        [Display(Name = "Kriter Açıklaması")]
        public string CriterionDescription { get; set; }

        [Display(Name = "Dinamik mi?")]
        public bool IsDynamic { get; set; }
        [Display(Name = "Detaylı mı?")]
        public bool IsDetailed { get; set; }
        [Display(Name = "Kriter Birimi")]
        public int? UnitId { get; set; }
        [Display(Name = "Kriter Birimi")]
        public string UnitName { get; set; } //!!(Değişti)Kriterin seçilmesi ile otomatik dolacağı için dropdown list değil textbox yaptım
        [Display(Name = "Sertifika")]
        public int? CertificateId { get; set; }
        [Display(Name = "Sertifika")]
        public string CertificateName { get; set; }
        [Display(Name = "Seviye")]
        public Level? Level { get; set; }
        [Display(Name = "Q-Faktor")]
        public decimal? Contrafactor { get; set; } //Q-factor
        [Display(Name = "Kabul Edilebilir Seviye")]
        public AQL? QualityCertificateSamplePlanAQL { get; set; }
        [Display(Name = "Ölçüm Aletleri")]
        public string ProductionEquipmentName { get; set; }
        public decimal? NominalSize { get; set; }
        [Display(Name = "Maximum Değer")]
        public decimal? MaxSize { get; set; }
        [Display(Name = "Minimum Değer")]
        public decimal? MinSize { get; set; }
        [Display(Name = "Satın Alma Kontrol")]
        public bool PurchasingControl { get; set; }
        [Display(Name = "Üretim Kontrol")]
        public bool ProductionControl { get; set; }
        [Display(Name = "Açıklama")]
        [MaxLength(4000)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

    }
}