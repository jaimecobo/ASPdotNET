using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace L08HandsOn.Migrations.WatchedMovies
{
    public partial class InitMigrationWatchedMovies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WatchedMovies",
                columns: table => new
                {
                    WatchedMovieId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    userId = table.Column<string>(type: "TEXT", nullable: false),
                    MovieId = table.Column<long>(type: "INTEGER", nullable: false),
                    StartTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchedMovies", x => x.WatchedMovieId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WatchedMovies");
        }
    }
}
