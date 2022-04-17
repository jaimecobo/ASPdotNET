using L05HandsOnDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;


namespace L05HandsOnDB.Controllers
{
    [Route("api/[Controller]")]

    public class TrackController : Controller
    {
        [HttpGet]
        public List<Track> GetData()
        {
            List<Track> tracks = new List<Track>();
            string dataSource = "Data Source=" + Path.GetFullPath("chinook.db");

            using (SqliteConnection conn = new SqliteConnection(dataSource))
            {
                conn.Open();
                string sql = $"select * from tracks limit 200;";

                using (SqliteCommand command = new SqliteCommand(sql, conn))
                {
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
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

                            tracks.Add(newTrack);
                        }
                    }
                }
                conn.Close();
            }
            return tracks;
        }
    }
}