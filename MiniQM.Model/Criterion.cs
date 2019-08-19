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
        public QualityCertificateSamplePlan QualityCertificateSamplePlanLevel { get; set; }
        [Display(Name = "Sertifika")]
        public QualityCertificateSamplePlan QualityCertificateSamplePlanCertificate { get; set; }
        [Display(Name = "Q-Faktor")]
        public QualityCertificateSamplePlan QualityCertificateSamplePlanContrafactor { get; set; } //Q-factor
        [Display(Name = "Kabul Edilebilir Seviye")]
        public QualityCertificateSamplePlan QualityCertificateSamplePlanAQL { get; set; }
        public QualityCertificateSamplePlan QualityCertificateSamplePlanId { get; set; }
        public QualityCertificateSamplePlan QualityCertificateSamplePlan { get; set; }

        [Display(Name = "Dinamik")]
        public bool IsDinamic { get; set; }
        [Display(Name = "Detaylı")]
        public bool IsDetailed { get; set; }
        public Unit UnitId { get; set; }
        [Display(Name = "Birim")]
        public Unit Unit { get; set; }
    }
}
