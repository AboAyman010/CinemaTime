﻿namespace CinemaTime.Models
{
    public class MovieImage
    {
        public int MovieImageId { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public string ImageUrl { get; set; }
    }
}
