using System;
using Xunit;
using Movies.Services;
using Moq;
using System.Linq;
using Movies.Services.Models;
using System.Collections.Generic;
using Movies.Domain;

namespace Movies.Services.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void SearchMoviesByFilter_NoFilterProvided_ExceptionThrown()
        {
            var repositoryMock = new Mock<IMoviesRespository>();
            var service = new MoviesSearchService(repositoryMock.Object);
            
            Assert.Throws<InvalidInputException>(() => service.SearchMoviesByFilter(new MovieFilter()));
        }

        [Fact]
        public void SearchMoviesByFilter_FilterContainsTitle_CorrectItemsReturned()
        {
            var movies = new List<Movie>(){
                new Movie {Id = 1, Title = "Match"},
                new Movie {Id = 1, Title = "NoMatch"}
            };
            var repositoryMock = new Mock<IMoviesRespository>();
            repositoryMock.Setup(r => r.GetMovies()).Returns(movies.AsQueryable());
            var service = new MoviesSearchService(repositoryMock.Object);
            
            var results = service.SearchMoviesByFilter(new MovieFilter(){Title="Match"});
            Assert.Equal(1, results.Single().Id);
        }

        [Fact]
        public void SearchMoviesByFilter_FilterContainsPartialTitle_CorrectItemsReturned()
        {
            var movies = new List<Movie>(){
                new Movie {Id = 1, Title = "Match"},
                new Movie {Id = 1, Title = "NoMatch"}
            };
            var repositoryMock = new Mock<IMoviesRespository>();
            repositoryMock.Setup(r => r.GetMovies()).Returns(movies.AsQueryable());
            var service = new MoviesSearchService(repositoryMock.Object);
            
            var results = service.SearchMoviesByFilter(new MovieFilter(){Title="Ma"});
            Assert.Equal(1, results.Single().Id);
        }

        [Fact]
        public void SearchMoviesByFilter_RatingsExist_CorrectAverageRatingReturned()
        {
            var movies = new List<Movie>(){
                new Movie {Id = 1, Title = "Match"},
                new Movie {Id = 1, Title = "NoMatch"}
            };
            var userRatings = new List<UserRating>(){
                    new UserRating(){UserId=1, MovieId=1, Rating=4},
                    new UserRating(){UserId=2, MovieId=1, Rating=2}};
            var repositoryMock = new Mock<IMoviesRespository>();
            repositoryMock.Setup(r => r.GetMovies()).Returns(movies.AsQueryable());
            repositoryMock.Setup(r => r.GetUserRatings()).Returns(userRatings.AsQueryable());
            
            var service = new MoviesSearchService(repositoryMock.Object);
            
            var results = service.SearchMoviesByFilter(new MovieFilter(){Title="Ma"});
            Assert.Equal(3, results.Single().AverageRating);
        }

         [Fact]
        public void SearchMoviesByFilter_RatingsExist_AverageRatingCorrectlyRoundedReturned()
        {
            var movies = new List<Movie>(){
                new Movie {Id = 1, Title = "Match"},
                new Movie {Id = 1, Title = "NoMatch"}
            };
             var userRatings = new List<UserRating>(){
                    new UserRating(){UserId=1, MovieId=1, Rating=4},
                    new UserRating(){UserId=2, MovieId=1, Rating=2},
                    new UserRating(){UserId=3, MovieId=1, Rating=1}};
            var repositoryMock = new Mock<IMoviesRespository>();
            repositoryMock.Setup(r => r.GetMovies()).Returns(movies.AsQueryable());
            repositoryMock.Setup(r => r.GetUserRatings()).Returns(userRatings.AsQueryable());
            
            var service = new MoviesSearchService(repositoryMock.Object);
            
            var results = service.SearchMoviesByFilter(new MovieFilter(){Title="Ma"});
            Assert.Equal(2.5, results.Single().AverageRating);
        }


      
    }
}
