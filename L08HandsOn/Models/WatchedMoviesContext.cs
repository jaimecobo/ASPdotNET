using Microsoft.EntityFrameworkCore;

namespace L08HandsOn.Models
{
    public class WatchedMoviesContext : DbContext
    {
        public WatchedMoviesContext(DbContextOptions<WatchedMoviesContext> options) : base(options)
        {

        }
        public DbSet<WatchedMovie> WatchedMovies { get; set; }
    }
}
