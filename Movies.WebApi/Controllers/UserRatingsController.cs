using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Movies.Domain;
using Movies.Repository;
using Movies.Services;
using Movies.Services.Models;

namespace Movies.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRatingsController : ControllerBase
    {
        private UserRatingService userRatingService;
        public UserRatingsController(UserRatingService userRatingService)
        {
            this.userRatingService = userRatingService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserRatingInput rating)
        {
            try
            {
                userRatingService.AddOrUpdateUserRating(rating);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
