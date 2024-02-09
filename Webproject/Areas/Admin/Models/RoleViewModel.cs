using System.ComponentModel.DataAnnotations;

namespace Webproject.Areas.Admin.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage ="Lutfen rol adi giriniz.")]
        public string name { get; set; }
    }
}
