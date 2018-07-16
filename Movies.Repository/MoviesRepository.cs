using System;
using Movies.Domain;
using Movies.Services;
using System.Linq;

namespace Movies.Repository
{
    public class MoviesRepository : IMoviesRespository
    {
        private MoviesContext moviesContext;
        public MoviesRepository(MoviesContext moviesContext)
        {
            this.moviesContext = moviesContext;
        }

        public IQueryable<Movie> GetMovies()
        {
            return moviesContext.Movies;
        }
        public IQueryable<UserRating> GetUserRatings()
        {
            return moviesContext.UserRatings;
        }
        public IQueryable<User> GetUsers()
        {
            return moviesContext.Users;
        }

        public void AddOrUpdateUserRating(UserRating rating)
        {
            var userRating = moviesContext.UserRatings.Where(ur => ur.UserId == rating.UserId && ur.MovieId == rating.MovieId).FirstOrDefault();
            if (userRating == null)
            {
                moviesContext.UserRatings.Add(rating);
            }
            else
            {
                userRating.Rating = rating.Rating;
            }

            moviesContext.SaveChanges();
        }
    }
}
