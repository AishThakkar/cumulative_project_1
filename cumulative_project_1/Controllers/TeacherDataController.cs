using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using cumulative_project_1.Models;
using MySql.Data.MySqlClient;

namespace cumulative_project_1.Controllers
{

    
    public class TeacherDataController : ApiController
    {
        
        private SchoolDbContext TeacherData = new SchoolDbContext();

        

        [HttpGet]
        public IEnumerable<Teacher> ListTeachers()
        {
            
            MySqlConnection Conn = TeacherData.DatabaseAccess();

            
            Conn.Open();

            
            MySqlCommand cmd = Conn.CreateCommand();

            
            cmd.CommandText = "Select * From Teachers";

            
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            
            List<Teacher> Teachers = new List<Teacher> { };

            
            while (ResultSet.Read())
            {
               
                int TeacherID = (int)ResultSet["teacherid"];
                string TeacherFname = ResultSet["teacherfname"].ToString();
                string TeacherLname = ResultSet["teacherlname"].ToString();
                string EmployeeNumber = ResultSet["employeenumber"].ToString();
                string HireDate = ResultSet["hiredate"].ToString();
                string Salary = ResultSet["salary"].ToString();

                Teacher NewTemp = new Teacher();
                NewTemp.TeacherID = TeacherID;
                NewTemp.TeacherFName = TeacherFname;
                NewTemp.TeacherLName = TeacherLname;
                NewTemp.EmployeeNumber = EmployeeNumber;
                NewTemp.HireDate = HireDate;
                NewTemp.Salary = Salary;

                
                Teachers.Add(NewTemp);
            }

            
            Conn.Close();

            
            return Teachers;
        }

        
        [HttpGet]
        public Teacher FindTeacher(int id)
        {
            Teacher TeacherTemp = new Teacher();

            
            MySqlConnection Conn = TeacherData.DatabaseAccess();

            
            Conn.Open();

            
            MySqlCommand cmd = Conn.CreateCommand();

            
            cmd.CommandText = "Select * from Teachers where teacherid = " + id;

            
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                
                int TeacherID = (int)ResultSet["teacherid"];
                string TeacherFname = ResultSet["teacherfname"].ToString();
                string TeacherLname = ResultSet["teacherlname"].ToString();
                string EmployeeNumber = ResultSet["employeenumber"].ToString();
                string HireDate = ResultSet["hiredate"].ToString();
                string Salary = ResultSet["salary"].ToString();

                TeacherTemp.TeacherID = TeacherID;
                TeacherTemp.TeacherFName = TeacherFname;
                TeacherTemp.TeacherLName = TeacherLname;
                TeacherTemp.EmployeeNumber = EmployeeNumber;
                TeacherTemp.HireDate = HireDate;
                TeacherTemp.Salary = Salary;
            }

            
            Conn.Close();

            
            Conn.Open();

           
            MySqlCommand cmd1 = Conn.CreateCommand();

            
            cmd1.CommandText = "Select * from classes where teacherid = " + id;

            
            MySqlDataReader ResultSet1 = cmd1.ExecuteReader();

            
            List<Course> TeacherCourse = new List<Course> { };

            while (ResultSet1.Read())
            {
                
                string CourseCodes = ResultSet1["classcode"].ToString();
                string CourseName = ResultSet1["classname"].ToString();

                Course NewCourse = new Course();
                NewCourse.ClassCode = CourseCodes;
                NewCourse.ClassName = CourseName;

                
                TeacherCourse.Add(NewCourse);
            }
            TeacherTemp.Courses = TeacherCourse;

            
            Conn.Close();

            
            return TeacherTemp;
        }
    }
}