using System;
using Movies.Domain;
using Movies.Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace Movies.Services
{
    public class UserRatingService
    {
        private IMoviesRespository moviesRepository;
        public UserRatingService(IMoviesRespository moviesRepository)
        {
            this.moviesRepository = moviesRepository;
        }

        public void AddOrUpdateUserRating(UserRatingInput userRating)
        {
            var movieExists = moviesRepository.GetMovies().Any(m => m.Id == userRating.MovieId);
            if (movieExists == false)
            {
                throw new NotFoundException("Invalid movie");
            }

            var userExists = moviesRepository.GetUsers().Any(u => u.Id == userRating.UserId);
            if (userExists == false)
            {
                throw new NotFoundException("Invalid user");
            }

            moviesRepository.AddOrUpdateUserRating(
              new UserRating()
              {
                  UserId = userRating.UserId,
                  MovieId = userRating.MovieId,
                  Rating = userRating.Rating
              });
        }
    }
}