﻿using Microsoft.Extensions.DependencyInjection;
using Movies.Services.Services.Actors;
using Movies.Services.Services.Cinemas;
using Movies.Services.Services.Halls;
using Movies.Services.Services.Events;
using Movies.Services.Services.Movies;
using Movies.Services.Services.Photos;
using Movies.Services.Services.Reviews;
using Movies.Services.Services.MovieTimes;

namespace Movies.API.Infrastructure.Extensions
{
    public static class ServicesExtension
    {
        public static void RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<ICinemaService, CinemaService>();
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<IHallService, HallService>();
            services.AddScoped<IActorService, ActorService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IMovieReviewService, MovieReviewService>();
            services.AddScoped<IMovieTimeService, MovieTimeService>();
        }
    }
}
