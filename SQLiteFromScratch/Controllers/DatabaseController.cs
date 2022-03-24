using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using SQLiteFromScratch.Models;

namespace SqliteFromScratch.Controllers
{
    // MVC is handling the routing for you.
    [Route("api/[Controller]")]
    
    public class DatabaseController : Controller
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
    }
}
