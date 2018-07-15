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
        public UserRatingService (IMoviesRespository moviesRepository)
        {
          this.moviesRepository = moviesRepository;
        }

        public void AddOrUpdateUserRating(UserRatingInput userRating)
        {
          moviesRepository.AddOrUpdateUserRating(
            new UserRating(){
              UserId = userRating.UserId,
              MovieId = userRating.MovieId,
              Rating = userRating.Rating
          });
        }
    }
}