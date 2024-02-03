using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using DocumentFormat.OpenXml.Office.MetaAttributes;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Policy;
using Webproject.Models;

namespace Webproject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminMessageController : Controller
    {
        Message2Manager message2Manager = new Message2Manager(new EfMessage2Repository());
        Context context = new Context();
        public IActionResult Index()
        {
            return View();
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
            MessageValue.MessageSenderUser = context.Users.Where(x => x.Id == MessageValue.MessageSenderID).FirstOrDefault();

            return View(MessageValue);

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
            return RedirectToAction("SendBox");
        }
        public PartialViewResult MessageAreaLeftBar()
        {
            return PartialView();
        }
    }
}
