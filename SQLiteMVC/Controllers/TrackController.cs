using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using SQLiteMVC.Models;


namespace SQLiteMVC.Controllers
{
    // MVC is handling the routing for you.
    [Route("api/[Controller]")]

    public class TrackController : Controller
    {
        // api/database
        [HttpGet]
        // change return type of GetData to List<Track>.
        public List<Track> GetData()
        {
            // tracks will be populated with the result of the query.
            //-------------------------------------------------------
            // tracks will be populated with the result of the query.
            List<Track> tracks = new List<Track>();

            // GetFullPath will complete the path for the file named passed in as a string.
            //-----------------------------------------------------------------------------
            // GetFullPath will return a string to complete the absolute path.
            string dataSource = "Data Source=" + Path.GetFullPath("chinook.db");

            // Initialize the connection to the .db file.
            // create a string to hold the SQL command.
            //-------------------------------------------
            // using will make sure that the resource is cleaned from memory after it exists
            // conn initializes the connection to the .db file.
            using (SqliteConnection conn = new SqliteConnection(dataSource))
            {
                conn.Open();
                // sql is the string that will be run as an sql command
                string sql = $"select * from tracks limit 200;";

                // create a new SQL command by combining the location and command string.
                //-----------------------------------------------------------------------
                // command combines the connection and the command string and creates the query
                using (SqliteCommand command = new SqliteCommand(sql, conn))
                {
                    // read each value that comes back from the query and do something to it.
                    //-----------------------------------------------------------------------
                    // reader allows you to read each value that comes back and do something to it.
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        // Loop through query exit when no more objects are left.
                        //-------------------------------------------------------
                        // Read returns true while there are more rows to advance to. then false when done.
                        while (reader.Read())
                        {
                            // map the data to the Track model
                            //--------------------------------
                            // map the data to the model.
                            Track newTrack = new Track()
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                AlbumId = reader.GetInt32(2),
                                MediaTypeId = reader.GetInt32(3),
                                GenreId = reader.GetInt32(4),
                                Composer = reader.GetValue(5).ToString(),
                                Milliseconds = reader.GetInt32(6),
                                Bytes = reader.GetInt32(7),
                                UnitPrice = reader.GetInt32(8)
                            };

                            // add each track to the list of tracks.
                            //--------------------------------------
                            // add each one to the list.
                            tracks.Add(newTrack);
                        }
                    }
                }
                // close the connection
                conn.Close();
            }

            return tracks;
        }

        //############################################################################################################
        //############################################################################################################

        //public List<Customer> GetData()
        //{
        //    List<Customer> customers = new List<Customer>();
        //    string dataSource = "Data Source=" + Path.GetFullPath("chinook.db");
        //    using (SqliteConnection conn = new SqliteConnection(dataSource))
        //    {
        //        conn.Open();

        //        string sql = $"select * from customers limit 20;";

        //        using (SqliteCommand command = new SqliteCommand(sql, conn))
        //        {
        //            using (SqliteDataReader reader = command.ExecuteReader())
        //            {
        //                CustomerMapper customerMapper = new(reader);
        //                while (reader.Read())
        //                {
        //                    //Customer newCustomer = new Customer()
        //                    //{

        //                    //    Id = reader.GetInt32(0),
        //                    //    FirstName = (reader.IsDBNull(1))?null:reader.GetString(1),
        //                    //    LastName = (reader.IsDBNull(2)) ? null : reader.GetString(2),
        //                    //    Company = (reader.IsDBNull(3)) ? null : reader.GetString(3),
        //                    //    Address = (reader.IsDBNull(4)) ? null : reader.GetString(4),
        //                    //    City = (reader.IsDBNull(5)) ? null : reader.GetString(5),
        //                    //    State = (reader.IsDBNull(6)) ? null : reader.GetString(6),
        //                    //    Country = (reader.IsDBNull(7)) ? null : reader.GetString(7),
        //                    //    PostalCode = (reader.IsDBNull(8)) ? null : reader.GetString(8),
        //                    //    Phone = (reader.IsDBNull(9)) ? null : reader.GetString(9),
        //                    //    Fax = (reader.IsDBNull(10)) ? null : reader.GetString(10),
        //                    //    Email = (reader.IsDBNull(11)) ? null : reader.GetString(11),
        //                    //    SupportRepId = reader.GetInt32(12),

        //                    //};
        //                    Customer newCustomer = customerMapper.ToCustomer(reader);
        //                    customers.Add(newCustomer);
        //                }
        //            }
        //            conn.Close();
        //        }

        //        return customers;
        //    }

        //}

        //############################################################################################################
        //############################################################################################################


        //public List<Employee> GetData()
        //{
        //    List<Employee> employees = new List<Employee>();
        //    string dataSource = "Data Source=" + Path.GetFullPath("chinook.db");
        //    using (SqliteConnection conn = new SqliteConnection(dataSource))
        //    {
        //        conn.Open();

        //        string sql = $"select * from employees;";

        //        using (SqliteCommand command = new SqliteCommand(sql, conn))
        //        {
        //            using (SqliteDataReader reader = command.ExecuteReader())
        //            {
        //                //CustomerMapper customerMapper = new(reader);
        //                while (reader.Read())
        //                {
        //                    Employee newEmployee = new Employee()
        //                    {
        //                        EmployeeId = reader.GetInt32(0),
        //                        LastName = (reader.IsDBNull(1)) ? null : reader.GetString(1),
        //                        FirstName = (reader.IsDBNull(2)) ? null : reader.GetString(2),
        //                        Title = (reader.IsDBNull(3)) ? null : reader.GetString(3),
        //                        ReportsTo = (reader.IsDBNull(4)) ? null : reader.GetInt32(4),
        //                        BirthDate = reader.GetDateTime(5),
        //                        HireDate = reader.GetDateTime(6),
        //                        Address = (reader.IsDBNull(7)) ? null : reader.GetString(7),
        //                        City = (reader.IsDBNull(8)) ? null : reader.GetString(8),
        //                        State = (reader.IsDBNull(9)) ? null : reader.GetString(9),
        //                        Country = (reader.IsDBNull(10)) ? null : reader.GetString(10),
        //                        PostalCode = (reader.IsDBNull(11)) ? null : reader.GetString(11),
        //                        Phone = (reader.IsDBNull(12)) ? null : reader.GetString(12),
        //                        Fax = (reader.IsDBNull(13)) ? null : reader.GetString(13),
        //                        Email = (reader.IsDBNull(14)) ? null : reader.GetString(14),


        //                    };
        //                    //Customer newCustomer = customerMapper.ToCustomer(reader);
        //                    employees.Add(newEmployee);
        //                }
        //            }
        //            conn.Close();
        //        }

        //        return employees;
        //    }

        //}


    }
}