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
    public class MoviesController : ControllerBase
    {
        private MoviesSearchService searchService;
        public MoviesController (MoviesSearchService searchService)
        {
          this.searchService = searchService;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<MovieResult>> Get([FromQuery]MovieFilter filter)
        {
                var movies = searchService.SearchMoviesByFilter(filter);
                if(movies.Any() == false)
                {
                     return NotFound("Movies not found");
                }
                return movies;
           
        }
    }
}
