using EntitiyLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogName).NotEmpty().WithMessage("Blog ismi bos birakilmamali.");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog icerigi bos birakilmamali.");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Blog gorseli bos birakilmamali.");
            RuleFor(x => x.BlogName).MaximumLength(100).WithMessage("Blog ismi en fazla 100 karakter olabilir.");
            RuleFor(x => x.BlogName).MinimumLength(5).WithMessage("Blog ismi en az 5 karakter olabilir.");
            RuleFor(x => x.BlogName).NotEmpty().WithMessage("Blog ismi bos birakilmamali.");

        }
    }
}
