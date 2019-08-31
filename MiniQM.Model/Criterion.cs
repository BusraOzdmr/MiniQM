using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Model
{
    public class Criterion:BaseEntity
    {
        [Display(Name = "Kriter")]
        public string Name { get; set; }        
        [Display(Name = "Seviye")]
        public Level Level { get; set; }
        [Display(Name = "Sertifika")]
        public int CertificateId { get; set; }
        public virtual Certificate Certificate { get; set; }
        [Display(Name = "Q-Faktor")]
        public decimal Contrafactor { get; set; } //Q-factor
        [Display(Name = "Kabul Edilebilir Seviye")]
        public AQL AQL { get; set; }

        [Display(Name = "Dinamik")]
        public bool IsDynamic { get; set; }
        [Display(Name = "Detaylı")]
        public bool IsDetailed { get; set; }
        
        [Display(Name = "Birim")]
        public int? UnitId { get; set; }
        public virtual Unit Unit { get; set; }
        [Display(Name="Ölçüm Aletleri")]
        public int? ProductionEquipmentId { get; set; }
        public virtual ProductionEquipment ProductionEquipment { get; set; }
        [Display(Name = "Kullanıcı")]
        public int? SystemUserId { get; set; }
        public virtual SystemUser SystemUser { get; set; }
        [Display(Name = "Bilgi Grubu")]
        public int? UserGroupId { get; set; }
        public virtual UserGroup UserGroup { get; set; }
        [Display(Name = "Kritik mi?")]
        public bool IsCritical { get; set; }
        [Display(Name = "Nominal Büyüklük")]
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

        public virtual ICollection<ChangeQualityPlan> ChangeQualityPlans { get; set; }
    }
}
