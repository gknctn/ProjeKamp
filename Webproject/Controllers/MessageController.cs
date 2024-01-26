using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Webproject.Models;

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
            var writerID = context.Users.Where(x => x.UserName == userName).Select(y => y.Id).FirstOrDefault();
            var values = message2Manager.GetInboxListByWriter(writerID);
            return View(values);
        }
        public IActionResult SendBox()
        {
            var userName = User.Identity.Name;
            var writerID = context.Users.Where(x => x.UserName == userName).Select(y => y.Id).FirstOrDefault();
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
        public IActionResult SendMessage(SendMessageModel p)
        {
            Message2 message = new Message2();
            var userName = User.Identity.Name;

            var SenderWriterID = context.Users.Where(x => x.UserName == userName).Select(y => y.Id).FirstOrDefault();

            var ReceiverWriterID = context.Users.Where(x => x.Email == p.ReceiverMail).Select(y => y.Id).FirstOrDefault();

            message.MessageSenderID = SenderWriterID;
            message.MessageReceiverID = ReceiverWriterID;
            message.MessageStatus = true;
            message.MessageSubject = p.Subject;
            message.MessageDetail = p.Message;
            message.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            message2Manager.TAdd(message);
            return RedirectToAction("InBox");
        }
    }
}
