using EntitiyLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class UserValidator : AbstractValidator<AppUser>
    {
        public UserValidator()
        {
            RuleFor(x=>x.NameSurname).NotEmpty().WithMessage("Ad soyad bos gecilemez");
            RuleFor(x=>x.UserName).NotEmpty().WithMessage("Kullanici adi bos gecilemez");
            RuleFor(x=>x.Email).NotEmpty().WithMessage("Mail bos gecilemez");
        }
    }
}
