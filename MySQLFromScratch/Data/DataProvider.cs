using MySqlFromScratch.Models;
using System.Data;

namespace MySqlFromScratch.Data
{
    public interface IMovieRatingProvider
    {
        List<MovieRating> GetAllData();
        MovieRating GetMovieRating(int id);

        void UpdateMovieRating(int id, MovieRating rating);
        void DeleteMovieRating(int id);

        int CreateMovieRating(MovieRating rating);

    }

    public class MemoryRatingDataProvider : IMovieRatingProvider
    {
        Dictionary<int, MovieRating> _data = new Dictionary<int, MovieRating>();
        public int CreateMovieRating(MovieRating rating)
        {
            _data.Add(rating.ID, rating);
            return rating.ID;
        }

        public void DeleteMovieRating(int id)
        {
            _data.Remove(id);
        }

        public List<MovieRating> GetAllData()
        {
            return _data.Values.ToList();
        }

        public MovieRating GetMovieRating(int id)
        {
            return _data[id];
        }

        public void UpdateMovieRating(int id, MovieRating rating)
        {
            _data[id] = rating;
        }
    }


    public class MySqlRatingProvider : IMovieRatingProvider
    {

        IDbConnection connection;

       public MySqlRatingProvider()
        {
            connection = new MySql.Data.MySqlClient.MySqlConnection();
            connection.ConnectionString = "Server=127.0.0.1;Database=adn103movies;Uid=root;";
            connection.Open();
        }
        public int CreateMovieRating(MovieRating rating)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "insert INTO ratings( Rating, Description, MinAge, LongerDescription) VALUES ( Rating,@description,@minage,@longer)";
                var p1 = command.CreateParameter();

                p1.ParameterName = "@id";
                p1.Value = rating.ID;
                p1.Direction = ParameterDirection.Input;

                command.Parameters.Add(p1);

                p1 = command.CreateParameter();

                p1.ParameterName = "@Rating";
                p1.Value = rating.Rating;
                p1.Direction = ParameterDirection.Input;

                command.Parameters.Add(p1);

                p1 = command.CreateParameter();

                p1.ParameterName = "@Description";
                p1.Value = rating.Description;
                p1.Direction = ParameterDirection.Input;

                command.Parameters.Add(p1);

                p1 = command.CreateParameter();

                p1.ParameterName = "@MinAge";
                p1.Value = rating.MinAge;
                p1.Direction = ParameterDirection.Input;

                command.Parameters.Add(p1);

                p1 = command.CreateParameter();

                p1.ParameterName = "@Longer";
                p1.Value = rating.LongerDescription;
                p1.Direction = ParameterDirection.Input;

                command.Parameters.Add(p1);

                var reader = command.ExecuteNonQuery();
                return 0;


            }
        }

        public void DeleteMovieRating(int id)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "delete from ratings where ID = @id";
                var p1 = command.CreateParameter();

                p1.ParameterName = "@id";
                p1.Value = id;
                p1.Direction = ParameterDirection.Input;

                command.Parameters.Add(p1);

                var reader = command.ExecuteNonQuery();

            }
        }

        public List<MovieRating> GetAllData()
        {
            List<MovieRating> rv = new List<MovieRating>();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "select * from ratings";
                var reader = command.ExecuteReader();
                MovieRatingMapper mapper = new MovieRatingMapper(reader);
                while (reader.Read())
                {
                    rv.Add(mapper.ToMovieRating(reader));
                }

                reader.Close();
            }
            
            return rv;
        }

        public MovieRating GetMovieRating(int id)
        {
            MovieRating? rv = null;
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "select * from ratings where ID = @id";
                var p1 = command.CreateParameter();
                
                p1.ParameterName = "@id";
                p1.Value = id;
                p1.Direction = ParameterDirection.Input;

                command.Parameters.Add(p1);

                var reader = command.ExecuteReader();
                MovieRatingMapper mapper = new MovieRatingMapper(reader);
                reader.Read();
                rv = mapper.ToMovieRating(reader);

                reader.Close();
            }
            return rv;
        }

        public void UpdateMovieRating(int id, MovieRating rating)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE ratings SET Rating=@Rating,Description=@description,MinAge=@minage,LongerDescription=@longer WHERE ID = @id ";
                var p1 = command.CreateParameter();

                p1.ParameterName = "@id";
                p1.Value = id;
                p1.Direction = ParameterDirection.Input;

                command.Parameters.Add(p1);

                p1 = command.CreateParameter();

                p1.ParameterName = "@Rating";
                p1.Value = rating.Rating;
                p1.Direction = ParameterDirection.Input;

                command.Parameters.Add(p1);

                p1 = command.CreateParameter();

                p1.ParameterName = "@Description";
                p1.Value = rating.Description;
                p1.Direction = ParameterDirection.Input;

                command.Parameters.Add(p1);

                p1 = command.CreateParameter();

                p1.ParameterName = "@MinAge";
                p1.Value = rating.MinAge;
                p1.Direction = ParameterDirection.Input;

                command.Parameters.Add(p1);

                p1 = command.CreateParameter();

                p1.ParameterName = "@Longer";
                p1.Value = rating.LongerDescription;
                p1.Direction = ParameterDirection.Input;

                command.Parameters.Add(p1);

                var reader = command.ExecuteNonQuery();
                

               
            }
        }
    }
}
