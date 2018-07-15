using System;
using Movies.Domain;
using Movies.Services;
using System.Linq;

namespace Movies.Repository
{
    public class MoviesRepository : IMoviesRespository
    {
        private MoviesContext moviesContext;
        public MoviesRepository (MoviesContext moviesContext)
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
    }
}
