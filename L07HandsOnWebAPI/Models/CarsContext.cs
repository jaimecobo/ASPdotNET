using Microsoft.EntityFrameworkCore;
namespace L07HandsOnWebAPI.Models
{
    public class CarsContext : DbContext
    {

        public CarsContext(DbContextOptions<CarsContext> options) : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }
    }
}





