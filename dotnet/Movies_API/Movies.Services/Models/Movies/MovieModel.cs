﻿using Movies.Services.Models.Actors;
using Movies.Services.Models.Photos;
using System;
using System.Collections.Generic;

namespace Movies.Services.Models.Movies
{
    public class MovieModel
    {
        public int Id { get; set; }
        public int CinemaId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public string TrailerLink { get; set; }
        public int ReleaseYear { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Country { get; set; }
        public string Language { get; set; }
        //Change to List of Genre class later
        public string Genre { get; set; }
        public int Length { get; set; }
        public IList<PhotoModel> Photos { get; set; }
        public IList<ActorModel> Actors { get; set; }
    }
}
