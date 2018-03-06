using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InformationEncodingAssignment.Models
{
    public class Student
    {
        
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string StudentAddress { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<StudentCourse> Courses { get; set; }
    }
}