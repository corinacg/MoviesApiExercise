using System;
using System.Collections.Generic;

namespace Movies.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public List<UserRating> Ratings { get; set; }
    }
}
