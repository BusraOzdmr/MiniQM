using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Model
{
    public class SystemUser: BaseEntity
    {
        [Display(Name="Kullanıcı Adı")]
        [Required] 
        public string UserName { get; set; }
        [Display(Name = "Telefon")]
        [Phone]
        public string ContactNumber { get; set; }
        [Display(Name = "Adı")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Soyadı")]
        [Required]
        public string Surname { get; set;  }
        [Display(Name = "Kontak Tipi")]
        [Required]
        public ContactType ContactType { get; set;}
        [Display(Name = "E-posta")]
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Display(Name = "Firma")]
        [Required]
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        [Display(Name = "Bölüm")]
        [Required]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        [Display(Name = "Pozisyon")]
        [Required]
        public int PositionId { get; set; }
        public Position Position { get; set; }
        [Display(Name = "Profil")]
        [Required]
        public string Profile { get; set; }
        [Display(Name = "Dosya Yolu")]
        [Required]
        public string FilePath { get; set; }
        public virtual ICollection<Criterion> Criterions { get; set; }
    }
}
