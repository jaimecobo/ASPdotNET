namespace L08HandsOnASPNetDB.Models
{
    public class Movie
    {
        public long MovieId { get; set; }
        public string? MovieTitle { get; set;}
        public string? MovieImage { get; set;}
        public string? MovieURL { get; set;} 
        public List<WatchedMovie>? watchedMovies { get; set; }
        
    }
}
