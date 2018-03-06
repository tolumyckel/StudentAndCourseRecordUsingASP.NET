using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InformationEncodingAssignment.Models;

namespace InformationEncodingAssignment.Controllers
{
    public class JsonController : Controller
    {
        private DataContext datacontext = new DataContext();
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Chart()
        {
            return View();
        }
        public JsonResult AllStudents()
        {
            string filepath1 = Server.MapPath("~/App_Data/student.csv");
            string filepath2 = Server.MapPath("~/App_Data/course.csv");
            string filepath3 = Server.MapPath("~/App_Data/studentcourse.csv");
            datacontext.Fetch(filepath1,filepath2,filepath3);
            return Json(datacontext.Students, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AllCourses()
        {
            string filepath1 = Server.MapPath("~/App_Data/student.csv");
            string filepath2 = Server.MapPath("~/App_Data/course.csv");
            string filepath3 = Server.MapPath("~/App_Data/studentcourse.csv");
            datacontext.Fetch(filepath1, filepath2, filepath3);
            return Json(datacontext.Courses, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CoursesforStudent(int id)
        {
            string filepath1 = Server.MapPath("~/App_Data/student.csv");
            string filepath2 = Server.MapPath("~/App_Data/course.csv");
            string filepath3 = Server.MapPath("~/App_Data/studentcourse.csv");
            datacontext.Fetch(filepath1, filepath2, filepath3);
            datacontext.CoursesforStudent(id);
            return Json(datacontext.result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult NumberofStudentsInCourses()
        {
            string filepath1 = Server.MapPath("~/App_Data/student.csv");
            string filepath2 = Server.MapPath("~/App_Data/course.csv");
            string filepath3 = Server.MapPath("~/App_Data/studentcourse.csv");
            datacontext.Fetch(filepath1, filepath2, filepath3);
            var courses = datacontext.Courses.ToList();
            Object[] countStudent = new Object[courses.Count()];
            var i = 0;
            foreach (Course course in courses)
            {
                IEnumerable<StudentCourse> items = new List<StudentCourse>();


                items = datacontext.StudentCourses.Where(x => x.CourseID == course.CourseID).ToList();

                countStudent[i] = new { count = items.Count(), name = course.CourseName };
                i += 1;
            }
            return Json(countStudent, JsonRequestBehavior.AllowGet);
        }

        public ActionResult School()
        {
            return View();
        }


    }
}