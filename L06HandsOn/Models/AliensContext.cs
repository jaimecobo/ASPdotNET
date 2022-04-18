using Microsoft.EntityFrameworkCore;

namespace L06HandsOn.Models{
    public class AliensContext : DbContext {
        public AliensContext(DbContextOptions<ContactsContext> options) : base(options) {

        }
        public DbSet<Alien> Aliens { get; set; }
    }
}