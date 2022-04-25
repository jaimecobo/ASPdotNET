using L08HandsOnASPNetDB02.Models;
using Microsoft.EntityFrameworkCore;

namespace L08HandsOnASPNetDB.Models
{
    public class WatchedMoviesContext : DbContext
    {
        public WatchedMoviesContext(DbContextOptions<WatchedMoviesContext> options) : base(options)
        {

        }
        public DbSet<WatchedMovie> WatchedMovies { get; set; }
    }
}
