using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cumulative_project_1.Models
{
    public class Teacher
    {

        public int TeacherID;
        public string TeacherFName;
        public string TeacherLName;
        public string EmployeeNumber;
        public string HireDate;
        public string Salary;
        public List<Course> Courses;
    }
}