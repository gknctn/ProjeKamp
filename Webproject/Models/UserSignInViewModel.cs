using System.ComponentModel.DataAnnotations;

namespace Webproject.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage ="Lutfen kullanici adini giriniz.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lutfen sifrenizi giriniz.")]
        public string Password { get; set; }
    }
}
