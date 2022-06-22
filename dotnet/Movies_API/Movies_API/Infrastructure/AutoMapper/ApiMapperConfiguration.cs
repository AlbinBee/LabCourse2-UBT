﻿using AutoMapper;
using Movies.Core.Domain;
using Movies.Services.Models.Cinemas;
using Movies.Services.Models.Movies;
using Movies.Services.Models.Photos;

namespace Movies.Api.Infrastructure.AutoMapper
{
    public class ApiMapperConfiguration : Profile
    {
        public ApiMapperConfiguration()
        {
            CreateMovieMapper();
            CreateCinemaMapper();
            CreatePhotoMapper();
        }

        private void CreateMovieMapper()
        {
            CreateMap<Movie, MovieModel>()
                .ReverseMap();

            CreateMap<Movie, MovieListModel>()
                .ReverseMap();

            CreateMap<MovieCreateModel, Movie>()
                .ReverseMap();            
            
            CreateMap<MovieModel, MovieCreateModel>()
                .ReverseMap();
        }

        private void CreateCinemaMapper()
        {
            CreateMap<Cinema, CinemaModel>()
                .ReverseMap();

            CreateMap<Cinema, CinemaListModel>()
                .ReverseMap();

            CreateMap<CinemaCreateModel, Cinema>()
                .ReverseMap();

            CreateMap<CinemaModel, CinemaCreateModel>()
                .ReverseMap();
        }

        private void CreatePhotoMapper()
        {
            CreateMap<Photo, PhotoModel>()
                .ReverseMap();
        }
    }
}
