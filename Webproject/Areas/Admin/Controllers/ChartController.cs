using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Webproject.Areas.Admin.Models;

namespace Webproject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CategoryChart()
        {
            List<CategoryModel> list = new List<CategoryModel>();
            list.Add(new CategoryModel
            {
                categoryname = "Teknoloji",
                categorycount = 10
            });
            list.Add(new CategoryModel
            {
                categoryname = "Yazılım",
                categorycount = 14
            });
            list.Add(new CategoryModel
            {
                categoryname = "Spor",
                categorycount = 5
            });
            list.Add(new CategoryModel
            {
                categoryname = "Sinema",
                categorycount = 2
            });

            return Json(new { jsonlist = list });
        }
    }
}
