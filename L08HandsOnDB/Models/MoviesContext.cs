using Microsoft.EntityFrameworkCore;

namespace L08HandsOnDB.Models
{
    public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options) : base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }
    }
}
