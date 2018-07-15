using System;
using System.Linq;
using Movies.Domain;

namespace Movies.Services
{
    public interface IMoviesRespository
    {
        IQueryable<Movie> GetMovies();
        IQueryable<UserRating> GetUserRatings();
        IQueryable<User> GetUsers();
    }
}
