using BusinessLayer.Concrete;
using ClosedXML.Excel;
using DataAccesLayer.Concrete;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Webproject.Areas.Admin.Models;

namespace Webproject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        public IActionResult ExportDynamicExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog listesi");
                worksheet.Cell(1, 1).Value = "Blog ID";
                worksheet.Cell(1, 2).Value = "Blog Adi";

                int BlogRowCount = 2;
                foreach (var item in GetBlogList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.ID;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Blogs.xlsx");
                }
            }
        }
        public IActionResult BlogListExcel()
        {
            return View();
        }
        public List<BlogModel> GetBlogList()
        {
            List<BlogModel> blogModel = new List<BlogModel>();
            using (var context = new Context())
            {
                blogModel = context.Blogs.Select(x=>new BlogModel
                {
                    ID=x.BlogID,
                    BlogName=x.BlogName
                }).ToList();
            }
                return blogModel;
        }
    }
}
