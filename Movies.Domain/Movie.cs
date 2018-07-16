using System;
using System.Collections.Generic;

namespace Movies.Domain
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public Genre Genre { get; set; }
        public int RunningTime { get; set; }
        public List<UserRating> Ratings { get; set; }
    }
}
