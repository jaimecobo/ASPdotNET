﻿using Microsoft.EntityFrameworkCore;

namespace L08HandsOn.Models
{
    public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options) : base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }
    }
}
