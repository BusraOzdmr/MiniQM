using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Model
{
    public enum QualityControlStatus
    {
        [Display(Name = "Karar Yok")]
        NoDecision = 0,
        [Display(Name = "Kabul")]
        Accept = 1,
        [Display(Name = "Ret")]
        İgnore = 2,
        [Display(Name = "Ayıklanmalı")]
        Extract = 3,
        [Display(Name = "Ayıklandı")]
        Extractad = 4,
        [Display(Name = "Sapmalı Kabul")]
        DeviatedAcceptance = 5,
    }
}
