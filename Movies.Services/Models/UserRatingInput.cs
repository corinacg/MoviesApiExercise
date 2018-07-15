using System;

namespace Movies.Services.Models
{
    public class UserRatingInput
    {
        public int UserId {get; set;}
        public int MovieId { get; set; }
        public int Rating {get; set;}   
    }
}
