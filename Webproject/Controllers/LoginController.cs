using DataAccesLayer.Concrete;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Webproject.Controllers
{
	public class LoginController : Controller
	{
		[AllowAnonymous]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> Index(Writer p)
		{
			Context context = new Context();
			var dataValue = context.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.Writerpassword == p.Writerpassword);
			if (dataValue != null)
			{
				var Claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name,p.WriterMail)
				};
				var useidentitiy = new ClaimsIdentity(Claims,"a");
				ClaimsPrincipal principal = new ClaimsPrincipal(useidentitiy);
				await HttpContext.SignInAsync(principal);

				return RedirectToAction("Index", "Dashboard");
			}
			else
			{
				return View();
			}
		}
		public async Task<IActionResult> Logout() 
		{
            await HttpContext.SignOutAsync();
			return RedirectToAction("Index","Blog");
		}
	}
}
/*
 Context context = new Context();
            var dataValue = context.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.Writerpassword == p.Writerpassword);
            if (dataValue != null)
            {
                HttpContext.Session.SetString("username", p.WriterMail);
                return RedirectToAction("Index", "Writer");
            }
            else
            {
                return View();
            }
 */