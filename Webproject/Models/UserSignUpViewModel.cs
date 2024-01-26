
using System.ComponentModel.DataAnnotations;

namespace Webproject.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name ="Ad")]
        [Required(ErrorMessage ="Lutfen ad soyad giriniz.")]
        public string Name { get; set; }

        [Display(Name = "Soyad")]
        [Required(ErrorMessage = "Lutfen ad soyad giriniz.")]
        public string Surname { get; set; }

        [Display(Name = "Sifre")]
        [Required(ErrorMessage = "Lutfen Sifre giriniz.")]
        public string Password { get; set; }

        [Display(Name = "Sifre Tekrar")]
        [Compare("Password",ErrorMessage = "Sifreler uyusmuyor.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Mail")]
        [Required(ErrorMessage = "Lutfen mail giriniz.")]
        public string Mail { get; set; }

        [Display(Name = "Kullanici adi")]
        [Required(ErrorMessage = "Lutfen kullanici adi giriniz.")]
        public string UserName { get; set; }
    }
}
