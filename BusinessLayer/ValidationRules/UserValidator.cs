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
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Ad soyad bos gecilemez");
            RuleFor(x=>x.Surname).NotEmpty().WithMessage("Ad soyad bos gecilemez");
            RuleFor(x=>x.UserName).NotEmpty().WithMessage("Kullanici adi bos gecilemez");
            RuleFor(x=>x.Email).NotEmpty().WithMessage("Mail bos gecilemez");


            //RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı boş geçilemez!");
            //RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar soyadı boş geçilemez!");
            //RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail adresi boş geçilemez!");
            //RuleFor(x => x.Writerpassword).NotEmpty().WithMessage("Şifre boş geçilemez!").Matches("^(?=.{8,32}$)(?=.*[A-Z])(?=.*[a-z])(?=.*[@#$%*?^:;+-._,])(?=.*[0-9]).*").WithMessage("Geçerli şifre giriniz.");
            //RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("İsim 2 karakterden uzun olmalıdır.");
            //RuleFor(x => x.WriterName).MaximumLength(40).WithMessage("İsim en fazla 40 karakter olmalıdır.");
            //RuleFor(x => x.WriterSurname).MinimumLength(2).WithMessage("İsim 2 karakterden uzun olmalıdır.");
            //RuleFor(x => x.WriterSurname).MaximumLength(40).WithMessage("İsim en fazla 40 karakter olmalıdır.");
            //RuleFor(x => x.WriterMail).MaximumLength(100).WithMessage("Mail en fazla 100 karakter olmalıdır.");
        }
    }
}
