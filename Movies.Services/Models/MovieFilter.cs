using System;
using System.Collections.Generic;
using Movies.Domain;

namespace Movies.Services.Models
{
    public class MovieFilter
    {
        public MovieFilter()
        {
            Genres = new List<Genre>();
        }
        public string Title { get; set; }
        public int? ReleaseYear { get; set; }
        public List<Genre> Genres { get; set; }
    }
}
