using BlogMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogMVC.Models
{
    public class BlogsContext : DbContext
    {
        public BlogsContext(DbContextOptions<BlogsContext> options) : base(options)
        {

        }
        public DbSet<Blog> Blogs { get; set; }
    }
}
