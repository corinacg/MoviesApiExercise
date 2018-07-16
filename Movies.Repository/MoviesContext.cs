using System;
using Microsoft.EntityFrameworkCore;
using Movies.Domain;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging;

namespace Movies.Repository
{
    public class MoviesContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRating> UserRatings { get; set; }

        public static readonly LoggerFactory MyLoggerFactory
        = new LoggerFactory(new[] {new ConsoleLoggerProvider((category, level) =>
                                    category == DbLoggerCategory.Database.Command.Name
                                    && level == LogLevel.Information, true)});

        public MoviesContext(DbContextOptions<MoviesContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRating>()
                .HasKey(ur => new { ur.UserId, ur.MovieId });

            modelBuilder.Entity<UserRating>()
                .HasOne(ur => ur.Movie)
                .WithMany(m => m.Ratings)
                .HasForeignKey(ur => ur.MovieId);

            modelBuilder.Entity<UserRating>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.Ratings)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<Movie>(e =>
            {
                e.Property(o => o.Title)
                .HasColumnType("TEXT COLLATE NOCASE");
            });

            AddSeedData(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
             => optionsBuilder.UseLoggerFactory(MyLoggerFactory);

        private void AddSeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
               new { Id = 1, Title = "Dogville", ReleaseYear = 2003, Genre = Genre.Crime | Genre.Drama, RunningTime = 178 },
               new { Id = 2, Title = "A Dog's Purpose", ReleaseYear = 2017, Genre = Genre.Adventure | Genre.Comedy | Genre.Family | Genre.Drama, RunningTime = 100 },
               new { Id = 3, Title = "The Emperor's Club", ReleaseYear = 2002, Genre = Genre.Drama, RunningTime = 109 },
               new { Id = 4, Title = "La La Land", ReleaseYear = 2016, Genre = Genre.Comedy | Genre.Drama | Genre.Music, RunningTime = 128 },
               new { Id = 5, Title = "The Shape of Water", ReleaseYear = 2017, Genre = Genre.Adventure | Genre.Drama | Genre.Fantasy, RunningTime = 123 },
               new { Id = 6, Title = "The Others", ReleaseYear = 2001, Genre = Genre.Horror | Genre.Mistery | Genre.Thriller, RunningTime = 104 },
               new { Id = 7, Title = "The Machinist", ReleaseYear = 2004, Genre = Genre.Drama | Genre.Thriller, RunningTime = 101 },
               new { Id = 8, Title = "Wonder Woman", ReleaseYear = 2017, Genre = Genre.Action | Genre.Adventure | Genre.Fantasy, RunningTime = 141 },
               new { Id = 9, Title = "Harry Potter and the Goblet of Fire", ReleaseYear = 2005, Genre = Genre.Adventure | Genre.Family | Genre.Fantasy, RunningTime = 157 },
               new { Id = 10, Title = "A Beautiful Mind", ReleaseYear = 2001, Genre = Genre.Biography | Genre.Drama, RunningTime = 135 }
               );


            modelBuilder.Entity<User>().HasData(
                new { Id = 1, UserName = "joe" },
                new { Id = 2, UserName = "alex" },
                new { Id = 3, UserName = "henry" });

            modelBuilder.Entity<UserRating>().HasData(
                new { UserId = 1, MovieId = 1, Rating = 5 },
                new { UserId = 1, MovieId = 3, Rating = 3 },
                new { UserId = 1, MovieId = 5, Rating = 1 },
                new { UserId = 1, MovieId = 7, Rating = 5 },
                new { UserId = 1, MovieId = 8, Rating = 3 },
                new { UserId = 1, MovieId = 2, Rating = 2 },
                new { UserId = 2, MovieId = 1, Rating = 2 },
                new { UserId = 2, MovieId = 3, Rating = 3 },
                new { UserId = 2, MovieId = 5, Rating = 1 },
                new { UserId = 2, MovieId = 7, Rating = 2 },
                new { UserId = 2, MovieId = 8, Rating = 3 },
                new { UserId = 2, MovieId = 4, Rating = 4 },
                new { UserId = 2, MovieId = 9, Rating = 1 },
                new { UserId = 2, MovieId = 10, Rating = 2 },
                new { UserId = 3, MovieId = 1, Rating = 4 },
                new { UserId = 3, MovieId = 3, Rating = 5 },
                new { UserId = 3, MovieId = 5, Rating = 3 },
                new { UserId = 3, MovieId = 7, Rating = 2 });
        }
    }
}
