using L08HandsOnASPNetDB02.Models;
using Microsoft.EntityFrameworkCore;

namespace L08HandsOnASPNetDB.Models
{
    public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options) : base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }
    }
}
