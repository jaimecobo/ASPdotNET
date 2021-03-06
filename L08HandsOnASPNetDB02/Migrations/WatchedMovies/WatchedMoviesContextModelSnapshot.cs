// <auto-generated />
using System;
using L08HandsOnASPNetDB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace L08HandsOnASPNetDB02.Migrations.WatchedMovies
{
    [DbContext(typeof(WatchedMoviesContext))]
    partial class WatchedMoviesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.2");

            modelBuilder.Entity("L08HandsOnASPNetDB02.Models.WatchedMovie", b =>
                {
                    b.Property<long>("WatchedMovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("MovieId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("WatchedMovieId");

                    b.ToTable("WatchedMovies");
                });
#pragma warning restore 612, 618
        }
    }
}
