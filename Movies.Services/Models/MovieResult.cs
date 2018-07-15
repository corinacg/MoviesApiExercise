using System;
using System.Collections.Generic;
using Movies.Domain;

namespace Movies.Services.Models
{
    public class MovieResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ReleaseYear {get; set;}
        public int RunningTime {get; set;}
        public double AverageRating {get; set;}
    }
}
