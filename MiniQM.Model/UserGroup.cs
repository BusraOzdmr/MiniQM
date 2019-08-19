using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Model
{
    public class UserGroup:BaseEntity
    {
        [Display(Name="Kullanıcı Grubu")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Açıklama Dili")]
        public Language Language { get; set; }
        public int? LanguageId { get; set; }
        [Display(Name = "Grup Açıklaması")]
        [MaxLength(4000)]
        public string Description { get; set; }
    }
}
