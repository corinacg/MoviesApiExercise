using System;
using System.ComponentModel.DataAnnotations;

namespace Movies.Services.Models
{
    public class UserRatingInput
    {
        public int UserId {get; set;}
        public int MovieId { get; set; }
        [Range(1, 5, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Rating {get; set;}   
    }
}
