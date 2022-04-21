namespace L08HandsOn.Models
{
    public class WatchedMovie
    {
        public long WatchedMovieId { get; set; }
        public string userId { get; set; } // user email address
        public long MovieId { get; set; } 
        public DateTime StartTime { get; set; }

    }
}
