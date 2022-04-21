﻿// <auto-generated />
using System;
using L08HandsOn.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace L08HandsOn.Migrations.WatchedMovies
{
    [DbContext(typeof(WatchedMoviesContext))]
    [Migration("20220228175254_InitMigrationWatchedMovies")]
    partial class InitMigrationWatchedMovies
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.2");

            modelBuilder.Entity("L08HandsOn.Models.WatchedMovie", b =>
                {
                    b.Property<long>("WatchedMovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("MovieId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("userId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("WatchedMovieId");

                    b.ToTable("WatchedMovies");
                });
#pragma warning restore 612, 618
        }
    }
}