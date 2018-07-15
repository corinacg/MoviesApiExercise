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
        public MoviesSearchService (IMoviesRespository moviesRepository)
        {
          this.moviesRepository = moviesRepository;
        }

        public List<MovieResult> SearchMoviesByFilter(MovieFilter filter)
        {
        if(string.IsNullOrEmpty(filter.Title) || filter.ReleaseYear.HasValue == false || filter.Genres.Any() == false)
        {
            throw new InvalidInputException();
        }
           var movies = moviesRepository.GetMovies().Where(m=>m.Title.StartsWith(filter.Title)).ToList()
            .Select(m => new MovieResult(){Id = m.Id, Title = m.Title, ReleaseYear = m.ReleaseYear, RunningTime = m.RunningTime}).ToList();

            var moviesIds = movies.Select(m=> m.Id).ToArray();
            var moviesRatings = moviesRepository.GetUserRatings().Where(ur => moviesIds.Contains(ur.MovieId)).GroupBy(ur=> ur.MovieId)
            .Select(g=> new {MovieId = g.Key,
                            AverageRating = g.Average(x => x.Rating)});
            foreach (var movie in movies)
            {
                movie.AverageRating = moviesRatings.SingleOrDefault(r=> r.MovieId == movie.Id).AverageRating;
            }

            return movies;
        }
    }
}
