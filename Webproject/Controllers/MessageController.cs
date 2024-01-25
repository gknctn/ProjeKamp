using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Webproject.Controllers
{
    public class MessageController : Controller
    {
        Message2Manager message2Manager = new Message2Manager(new EfMessage2Repository());
        Context context = new Context();

        public MessageController(Context context)
        {
            this.context = context;
        }

        public IActionResult InBox()
        {
            var userName = User.Identity.Name;
            var writerMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerID = context.Writers.Where(x => x.WriterMail == writerMail).Select(y => y.WriterID).FirstOrDefault();
            var values = message2Manager.GetInboxListByWriter(writerID);
            return View(values);
        }
        public IActionResult SendBox()
        {
            var userName = User.Identity.Name;
            var writerMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerID = context.Writers.Where(x => x.WriterMail == writerMail).Select(y => y.WriterID).FirstOrDefault();
            var values = message2Manager.GetSendboxListByWriter(writerID);
            return View(values);
        }
        public IActionResult MessageDetail(int id)
        {
            var MessageValue = message2Manager.TGetById(id);
            return View(MessageValue);
        }
        public IActionResult MessageDelete(int id)
        {
            var MessageValue = message2Manager.TGetById(id);
            message2Manager.TDelete(MessageValue);
            return View();
        }
        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendMessage(Message2 p)
        {
            var userName = User.Identity.Name;
            var writerMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var SenderWriterID = context.Writers.Where(x => x.WriterMail == writerMail).Select(y => y.WriterID).FirstOrDefault();
            //BURAYA ALICI ID SINI MAIL ADRESI UZERINDEN CEKEREK DINAMIK HALE GETIRECEGIM.
            //var ReceiverWriterID = context.Writers.Where(x => x.WriterMail == writerMail).Select(y => y.WriterID).FirstOrDefault();
            //MessageReceiverID
            p.MessageSenderID = SenderWriterID;
            //p.MessageReceiverID = 2;
            p.MessageStatus = true;
            p.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            message2Manager.TAdd(p);
            return RedirectToAction("InBox");
        }
    }
}
