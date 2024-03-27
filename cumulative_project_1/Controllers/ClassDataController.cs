using MySql.Data.MySqlClient;
using cumulative_project_1.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace cumulative_project_1.Controllers
{
    ///  Controller for access class table data from school database
    ///  A WebAPI Controller which allows you to access information about classes
    public class ClassDataController : ApiController
    {
        
        private SchoolDbContext ClassData = new SchoolDbContext();

        

        [HttpGet]
        public IEnumerable<Course> ListClasses()
        {
            
            MySqlConnection Conn = ClassData.DatabaseAccess();

            
            Conn.Open();

            
            MySqlCommand cmd = Conn.CreateCommand();

            
            cmd.CommandText = "Select * From classes";

           
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            
            List<Course> Classes = new List<Course> { };

           
            while (ResultSet.Read())
            {
                
                int ClassID = (int)ResultSet["classid"];
                string ClassCode = ResultSet["classcode"].ToString();
                int TeacherID = (int)ResultSet["teacherid"]; 
                DateTime StartDate = (DateTime)ResultSet["startdate"];
                DateTime EndDate = (DateTime)ResultSet["finishdate"];
                string ClassName = ResultSet["classname"].ToString();

                Course NewTemp = new Course();
                NewTemp.ClassID = ClassID;
                NewTemp.ClassCode = ClassCode;
                NewTemp.TeacherId = TeacherID;
                NewTemp.StartDate = StartDate;
                NewTemp.FinishDate = EndDate;
                NewTemp.ClassName = ClassName;

                
                Classes.Add(NewTemp);
            }

            
            Conn.Close();

            
            return Classes;
        }

        
        [HttpGet]
        public Course FindClass(int id)
        {
            Course ClassTemp = new Course();

            
            MySqlConnection Conn = ClassData.DatabaseAccess();

            
            Conn.Open();

            
            MySqlCommand cmd = Conn.CreateCommand();

            
            cmd.CommandText = "Select * from Classes where classid = " + id;

            
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                
                int ClassID = (int)ResultSet["classid"];
                string ClassCode = ResultSet["classcode"].ToString();
                int TeacherID = (int)ResultSet["teacherid"]; 
                DateTime StartDate = (DateTime)ResultSet["startdate"];
                DateTime EndDate = (DateTime)ResultSet["finishdate"];
                string ClassName = ResultSet["classname"].ToString();

                ClassTemp.ClassID = ClassID;
                ClassTemp.ClassCode = ClassCode;
                ClassTemp.TeacherId = TeacherID;
                ClassTemp.StartDate = StartDate;
                ClassTemp.FinishDate = EndDate;
                ClassTemp.ClassName = ClassName;
            }

           
            Conn.Close();

            
            Conn.Open();

            
            MySqlCommand cmd1 = Conn.CreateCommand();

            
            cmd1.CommandText = "Select teacherfname,teacherlname from teachers where teacherid = " + id;

            
            MySqlDataReader ResultSet1 = cmd1.ExecuteReader();

            while (ResultSet1.Read())
            {
                
                string TeacherFirstName = ResultSet1["teacherfname"].ToString();
                string TeacherLastName = ResultSet1["teacherlname"].ToString();

                ClassTemp.TeacherName = TeacherFirstName + " " + TeacherLastName;
            }

            
            Conn.Close();

            
            return ClassTemp;
        }
    }

}