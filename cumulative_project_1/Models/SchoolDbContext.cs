using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace cumulative_project_1.Models
{
    public class SchoolDbContext
    {

            private static string User { get { return "root"; } }
            private static string Password { get { return "root"; } }
            private static string Database { get { return "schooldb"; } }
            private static string Server { get { return "localhost"; } }
            private static string Port { get { return "3306"; } }


            protected static string DatabaseConnectionString
            {
                get
                {


                    return "server = " + Server
                        + "; user = " + User
                        + "; database = " + Database
                        + "; port = " + Port
                        + "; password = " + Password
                        + "; convert zero datetime = True";
                }
            }



            public MySqlConnection DatabaseAccess()
            {
                return new MySqlConnection(DatabaseConnectionString);
            }
        }
    }

