using System;

namespace Movies.Domain
{
    public class UserRating
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public int Rating { get; set; }
        public Movie Movie { get; set; }
        public User User { get; set; }
    }
}
