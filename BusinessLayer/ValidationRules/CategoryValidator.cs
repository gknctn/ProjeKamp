using EntitiyLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator() 
        {
            RuleFor(x=>x.CategoryName).NotEmpty().WithMessage("Kategori adi alani bos gecilemez.");
            RuleFor(x=>x.CategoryName).MaximumLength(50).WithMessage("Kategori adi en fazla 50 karakter olmalidir.");
            RuleFor(x=>x.CategoryName).MinimumLength(2).WithMessage("Kategori adi en az 2 karakter olmalidir.");
            RuleFor(x=>x.CategoryDescription).NotEmpty().WithMessage("Kategori Aciklama alani bos gecilemez.");
            RuleFor(x=>x.CategoryName).NotEmpty().WithMessage("Kategori adi alani bos gecilemez.");
            RuleFor(x=>x.CategoryName).NotEmpty().WithMessage("Kategori adi alani bos gecilemez.");
        }
    }
}
