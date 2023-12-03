using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class NewsLetterManager : INewsLetterService
    {
        INewsletterDal _NewsletterDal;

        public NewsLetterManager(INewsletterDal newsletterDal)
        {
            _NewsletterDal = newsletterDal;
        }

        public void AddNewsLetter(NewsLetter newsLetter)
        {
            _NewsletterDal.Insert(newsLetter);
        }
    }
}
