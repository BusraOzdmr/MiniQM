using MiniQM.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniQM.Admin.Models
{
    public class CriterionViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Kriter")]
        public string Name { get; set; }
        [Display(Name = "Seviye")]
        public Level? Level { get; set; }
        [Display(Name = "Sertifika")]
        public int? CertificateId { get; set; }
        [Display(Name = "Sertifika")]
        public string CertificateName { get; set; }
        [Display(Name = "Q-Faktor")]
        public decimal? Contrafactor { get; set; } //Q-factor
        [Display(Name = "Kabul Edilebilir Seviye")]
        public AQL? AQL { get; set; }

        [Display(Name = "Dinamik")]
        public bool IsDynamic { get; set; }
        [Display(Name = "Detaylı")]
        public bool IsDetailed { get; set; }

        [Display(Name = "Birim")]
        public int? UnitId { get; set; }
        [Display(Name = "Birim")]
        public string UnitName { get; set; }
        [Display(Name = "Ölçüm Aletleri")]
        public int? ProductionEquipmentId { get; set; }
        [Display(Name = "Ölçüm Aletleri")]
        public string ProductionEquipmentName { get; set; }
        [Display(Name = "Kullanıcı")]
        public int? SystemUserId { get; set; }
        [Display(Name = "Kullanıcı")]
        public string SystemUserUserName { get; set; }
        [Display(Name = "Bilgi Grubu")]        
        public int? UserGroupId { get; set; }
        [Display(Name = "Bilgi Grubu")]
        public string UserGroupName { get; set; }
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
        [Display(Name = "Açıklama")]
        [MaxLength(4000)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}