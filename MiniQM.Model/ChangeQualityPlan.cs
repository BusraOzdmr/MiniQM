using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Model
{
    public class ChangeQualityPlan:BaseEntity
    {
        [Display(Name="Kalite Planı No")]
        public int QualityPlanId { get; set; }
        public virtual QualityPlan QualityPlan { get; set; }
        [Display(Name = "Malzeme İndeksi")]
        public int? MaterialId { get; set; }
        public virtual Material Material { get; set; }
        [Display(Name = "Kriter")]
        public int? CriterionId { get; set; }
        public virtual Criterion Criterion { get; set; }
        [Display(Name = "Dinamik mi?")]
        public bool IsDynamic { get; set; }
        [Display(Name = "Detaylı mı?")]
        public bool IsDetailed { get; set; }
        [Display(Name = "Kriter Birimi")]
        public int? UnitId { get; set; } 
        public virtual Unit Unit { get; set; }
        [Display(Name = "Sertifika")]
        public int? CertificateId { get; set; }
        public virtual Certificate Certificate { get; set; }
        [Display(Name = "Seviye")]
        public Level? Level { get; set; }
        [Display(Name = "Q-Faktor")]
        public decimal? Contrafactor { get; set; } //Q-factor
        [Display(Name = "Kabul Edilebilir Seviye")]
        public AQL? AQL { get; set; }
        [Display(Name = "Ölçüm Aletleri")]
        public int? ProductionEquipmentId { get; set; }
        public virtual ProductionEquipment ProductionEquipment { get; set; }
        public decimal? NominalSize { get; set; }
        [Display(Name = "Maximum Değer")]
        public decimal? MaxSize { get; set; }
        [Display(Name = "Minimum Değer")]
        public decimal? MinSize { get; set; }
        [Display(Name = "Satın Alma Kontrol")]
        public bool PurchasingControl { get; set; }
        [Display(Name = "Üretim Kontrol")]
        public bool ProductionControl { get; set; }
        public string Description { get; set; }
    }
}
