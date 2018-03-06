using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InformationEncodingAssignment.Models
{
    public class Course
    {
        
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public ICollection<StudentCourse> Students { get; set; }
    }
}