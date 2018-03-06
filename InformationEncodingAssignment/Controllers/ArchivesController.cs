using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InformationEncodingAssignment.Models;
using System.IO;

namespace InformationEncodingAssignment.Controllers
{
    public class ArchivesController : Controller
    {
        // GET: Archives
        public ActionResult Archive()
        {
            return View();
        }
        public JsonResult ArchiveStudentCountFromfile()
        {
            List<ArchiveStudentCount> items = new List<ArchiveStudentCount>();


            string filepath = Server.MapPath("~/App_Data/ArchiveStudentCounts.csv");
            var reader = new StreamReader(filepath);

            int index = 0;

            while (reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                if (index > 0)
                {
                    items.Add(new ArchiveStudentCount { Year = values[0], Count = Convert.ToInt32(values[1]) });
                    //item.Add(values);
                }
                index++;
            }
            items.Add(new ArchiveStudentCount { Year = "2011", Count = 70 });
            items.Add(new ArchiveStudentCount { Year = "2012", Count = 100 });
            items.Add(new ArchiveStudentCount { Year = "2013", Count = 128 });
            items.Add(new ArchiveStudentCount { Year = "2014", Count = 68 });
            items.Add(new ArchiveStudentCount { Year = "2015", Count = 106 });
            items.Add(new ArchiveStudentCount { Year = "2016", Count = 300 });
            items.Add(new ArchiveStudentCount { Year = "2017", Count = 90 });



            return (Json(items, JsonRequestBehavior.AllowGet));
        }

        
    }
}