using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Webproject.Areas.Admin.Models;

namespace Webproject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WriterList()
        {
            var jsonWriter = JsonConvert.SerializeObject(writers);
            return Json(jsonWriter);
        }
        [HttpPost]
        public IActionResult WriterAdd(WriterModel writer)
        {
            writers.Add(writer);
            var jsonWriter = JsonConvert.SerializeObject(writer);
            return Json(jsonWriter);
        }
        [HttpPost]
        public IActionResult WriterDelete(int id)
        {
            var writer = writers.FirstOrDefault(x=>x.ID == id);
            writers.Remove(writer);
            return Json(writer);
        }
        [HttpPost]
        public IActionResult WriterUpdate(WriterModel writerParam)
        {
            var writer = writers.FirstOrDefault(x => x.ID == writerParam.ID);
            writer.ID = writerParam.ID;
            writer.Name = writerParam.Name;
            var jsonWriter = JsonConvert.SerializeObject(writer);
            return Json(jsonWriter);
        }
        public IActionResult GetWriterByID(int writerid)
        {
            var findwriter = writers.FirstOrDefault(x => x.ID == writerid);
            var jsonwriters= JsonConvert.SerializeObject(findwriter);
            return Json(jsonwriters);
        }
        public static List<WriterModel> writers = new List<WriterModel>
        {
            new WriterModel
            {
                ID = 1,
                Name="Gokhan"
            },
            new WriterModel
            {
                ID = 2,
                Name="Irem"
            },
            new WriterModel
            {
                ID = 3,
                Name="Gokce"
            }
        };
    }
}
