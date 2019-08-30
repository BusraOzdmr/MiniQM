using MiniQM.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniQM.Admin.Models
{
    public class SystemUserViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Kullanıcı Adı")]
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
        public string Surname { get; set; }
        [Display(Name = "Firma")]
        public int CompanyId { get; set; }
        [Display(Name = "Firma")]
        public string CompanyName { get; set; }

        [Display(Name = "Bölüm")]

        public int DepartmentId { get; set; }
        [Display(Name = "Bölüm")]
        public string DepartmentName { get; set; }

        [Display(Name = "Pozisyon")]

        public int? PositionId { get; set; }
        [Display(Name = "Pozisyon")]
        public string PositionName { get; set; }
        [Display(Name = "Kontak Tipi")]
        [Required]
        public ContactType ContactType { get; set; }
        [Display(Name = "E-posta")]
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        
        
        
        
        [Display(Name = "Profil")]
        [Required]
        public string Profile { get; set; }
        [Display(Name = "Dosya Yolu")]
        [Required]
        public string FilePath { get; set; }

        [Display(Name = "Aktif Mi?")]
        public bool IsActive { get; set; }

    }
}