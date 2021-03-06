using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ScaffoldExistingExample.Models
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {

        }

        public virtual DbSet<customer> customers { get; set; } = null!;
        public virtual DbSet<track> tracks { get; set; } = null!;

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     if (!optionsBuilder.IsConfigured)
        //     {
        //         optionsBuilder.UseSqlite("name=default");
        //     }
        // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<customer>(entity =>
            {
                entity.HasIndex(e => e.SupportRepId, "IFK_CustomerSupportRepId");

                entity.Property(e => e.Address).HasColumnType("NVARCHAR(70)");

                entity.Property(e => e.City).HasColumnType("NVARCHAR(40)");

                entity.Property(e => e.Company).HasColumnType("NVARCHAR(80)");

                entity.Property(e => e.Country).HasColumnType("NVARCHAR(40)");

                entity.Property(e => e.Email).HasColumnType("NVARCHAR(60)");

                entity.Property(e => e.Fax).HasColumnType("NVARCHAR(24)");

                entity.Property(e => e.FirstName).HasColumnType("NVARCHAR(40)");

                entity.Property(e => e.LastName).HasColumnType("NVARCHAR(20)");

                entity.Property(e => e.Phone).HasColumnType("NVARCHAR(24)");

                entity.Property(e => e.PostalCode).HasColumnType("NVARCHAR(10)");

                entity.Property(e => e.State).HasColumnType("NVARCHAR(40)");

                
            });

            modelBuilder.Entity<track>(entity =>
            {
                entity.HasIndex(e => e.AlbumId, "IFK_TrackAlbumId");

                entity.HasIndex(e => e.GenreId, "IFK_TrackGenreId");

                entity.HasIndex(e => e.MediaTypeId, "IFK_TrackMediaTypeId");

                entity.Property(e => e.Composer).HasColumnType("NVARCHAR(220)");

                entity.Property(e => e.Name).HasColumnType("NVARCHAR(200)");

                entity.Property(e => e.UnitPrice).HasColumnType("NUMERIC(10,2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
