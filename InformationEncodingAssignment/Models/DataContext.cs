using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InformationEncodingAssignment.Models
{
    public class DataContext
    {
        public List<string> StudentList = new List<string>();
        public List<string> CourseList = new List<string>();
        public List<string> StudentCourseList = new List<string>();
        public List<Course> result = new List<Course>();


        public DataContext()
        {
            
        }

        public void Fetch(string filepath1,string filepath2,string filepath3)
        {
            
            FetchStudent(filepath1);
             FetchCourse(filepath2);
             FetchStudentCourse(filepath3);

           
            foreach (string line in StudentList)
            {
                if (line == StudentList[0])
                {
                    continue;
                }
                else
                {


                    string[] properties = line.Split(',');
           
                    Students.Add(new Student { StudentID = Int32.Parse(properties[0]), StudentName = properties[1],StudentAddress = properties[2],PhoneNumber = properties[3] });


           
                }
            }
            foreach (string line in CourseList)
            {
                if (line == CourseList[0])
                {
                    continue;
                }
                else
                {


                    string[] properties = line.Split(',');
           
                    Courses.Add(new Course { CourseID = Int32.Parse(properties[0]), CourseName = properties[1] });

                   
           
                }
            }
            foreach (string line in StudentCourseList)
            {
                if (line == StudentCourseList[0])
                {
                    continue;
                }
                else
                {


                    string[] properties = line.Split(',');

                    StudentCourses.Add(new StudentCourse { id = Int32.Parse(properties[0]), StudentID = Int32.Parse(properties[1]), CourseID = Int32.Parse(properties[2]) });



                }

            }

            
        }

        public void FetchStudent(String filename)
        {
            string line = "";

            using (System.IO.StreamReader file = new System.IO.StreamReader(filename))
                while ((line = file.ReadLine()) != null)
                {
                    line.Skip(1);
                    StudentList.Add(line);
                }

        }

        public void FetchCourse(String filename)
        {
            string line = "";

            using (System.IO.StreamReader file = new System.IO.StreamReader(filename))
                while ((line = file.ReadLine()) != null)
                {
                    CourseList.Add(line);
                }

        }

        public void FetchStudentCourse(String filename)
        {
            string line = "";

            using (System.IO.StreamReader file = new System.IO.StreamReader(filename))
                while ((line = file.ReadLine()) != null)
                {
                    StudentCourseList.Add(line);
                }

        }

        public void CoursesforStudent(int id)
        {
          //  IEnumerable<StudentCourse> result = new List<StudentCourse>();
            IEnumerable<StudentCourse> studentcourse = new List<StudentCourse>();
            
            studentcourse = StudentCourses.Where(s => s.StudentID == id);
            foreach(StudentCourse scourse in studentcourse)
            {
                // course = Courses.Where(c => c.CourseID == scourse.CourseID).ToList();
                Course course = new Course();
                course = Courses.Find(c => c.CourseID == scourse.CourseID);
                result.Add(course);
            }   
        }


        public List<Student> Students { get; set; } = new List<Student>();
        public List<Course> Courses { get; set; } = new List<Course>();
        public List<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    }
}