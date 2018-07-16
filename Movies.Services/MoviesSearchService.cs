using System;
using Movies.Domain;
using Movies.Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace Movies.Services
{
    public class MoviesSearchService
    {
        private IMoviesRespository moviesRepository;
        public MoviesSearchService(IMoviesRespository moviesRepository)
        {
            this.moviesRepository = moviesRepository;
        }

        public List<MovieResult> SearchMoviesByFilter(MovieFilter filter)
        {
            if (string.IsNullOrEmpty(filter.Title) && filter.ReleaseYear.HasValue == false && filter.Genres.Any() == false)
            {
                throw new InvalidInputException();
            }
            var moviesQuery = moviesRepository.GetMovies();
            if (string.IsNullOrEmpty(filter.Title) == false)
            {
                moviesQuery = moviesQuery.Where(m => m.Title.StartsWith(filter.Title));
            }

            if (filter.ReleaseYear.HasValue)
            {
                moviesQuery = moviesQuery.Where(m => m.ReleaseYear == filter.ReleaseYear);
            }

            if (filter.Genres.Any())
            {
                var aggregatedValue = filter.Genres.Aggregate((aggr, next) => next | aggr);
                moviesQuery = moviesQuery.Where(m => (m.Genre & aggregatedValue) == aggregatedValue);
            }


            var movies = moviesQuery.Select(m => new MovieResult()
            {
                Id = m.Id,
                Title = m.Title,
                ReleaseYear = m.ReleaseYear,
                RunningTime = m.RunningTime,
                AverageRating = (int)m.Genre

            }).ToList();

            var moviesIds = movies.Select(m => m.Id).ToArray();
            var moviesRatings = moviesRepository.GetUserRatings().Where(ur => moviesIds.Contains(ur.MovieId)).GroupBy(ur => ur.MovieId)
            .Select(g => new
            {
                MovieId = g.Key,
                AverageRating = g.Average(x => x.Rating)
            }).ToList();
            foreach (var movie in movies)
            {
                movie.AverageRating = RoundingUtils.RoundToNearestDot5(moviesRatings.SingleOrDefault(r => r.MovieId == movie.Id)?.AverageRating);
            }

            return movies;
        }

        public List<MovieResult> SearchTopMoviesByTotalAverageRating()
        {
            var movies = moviesRepository.GetUserRatings().GroupBy(ur => new { ur.MovieId, ur.Movie.Title, ur.Movie.ReleaseYear, ur.Movie.RunningTime })
               .Select(g => new MovieResult()
               {
                   Id = g.Key.MovieId,
                   Title = g.Key.Title,
                   ReleaseYear = g.Key.ReleaseYear,
                   RunningTime = g.Key.RunningTime,
                   AverageRating = g.Average(x => x.Rating)
               })
                 .OrderByDescending(m => m.AverageRating).ThenBy(m => m.Title).Take(5).ToList();
            foreach (var movie in movies)
            {
                movie.AverageRating = RoundingUtils.RoundToNearestDot5(movie.AverageRating);
            }

            return movies;
        }

        public List<MovieResult> SearchTopMoviesByUserRating(int userId)
        {
            var moviesIds = moviesRepository.GetUserRatings().Where(ur => ur.UserId == userId)
            .OrderByDescending(ur => ur.Rating).ThenBy(ur => ur.Movie.Title).Take(5).Select(ur => ur.MovieId).ToArray();

            var movies = moviesRepository.GetUserRatings().Where(ur => moviesIds.Contains(ur.MovieId))
               .GroupBy(ur => new { ur.MovieId, ur.Movie.Title, ur.Movie.ReleaseYear, ur.Movie.RunningTime })
               .Select(g => new MovieResult()
               {
                   Id = g.Key.MovieId,
                   Title = g.Key.Title,
                   ReleaseYear = g.Key.ReleaseYear,
                   RunningTime = g.Key.RunningTime,
                   AverageRating = g.Average(x => x.Rating)
               }).ToList();
            movies = movies.OrderBy(m => Array.IndexOf(moviesIds, m.Id)).ToList();

            foreach (var movie in movies)
            {
                movie.AverageRating = RoundingUtils.RoundToNearestDot5(movie.AverageRating);
            }

            return movies;
        }
    }
}
