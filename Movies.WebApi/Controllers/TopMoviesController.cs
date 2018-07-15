using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Movies.Domain;
using Movies.Repository;
using Movies.Services.Models;
using Movies.Services;

namespace Movies.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopMoviesController : ControllerBase
    {
        private MoviesSearchService searchService;
        public TopMoviesController (MoviesSearchService searchService)
        {
          this.searchService = searchService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MovieResult>> Get()
        {
            var movies = searchService.SearchTopMoviesByTotalAverageRating();
             if(movies.Any() == false)
             {
                 return NotFound("Movies not found");
             }
             return movies;
        }

        [HttpGet("{userId}")]
        public ActionResult<IEnumerable<MovieResult>> Get(int userId)
        {
            var movies = searchService.SearchTopMoviesByUserRating(userId);
             if(movies.Any() == false)
             {
                 return NotFound("Movies not found");
             }
             return movies;
        }
    }
}
