namespace L08HandsOnASPNetDB02.Models
{
    public class WatchedMovie
    {
        public long WatchedMovieId { get; set; }
        public string? UserId { get; set; } // user email
        public long MovieId { get; set; }
        public DateTime StartTime { get; set; }
    }
}
