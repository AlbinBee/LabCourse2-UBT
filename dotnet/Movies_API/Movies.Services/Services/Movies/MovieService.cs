﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Movies.Core.Domain;
using Movies.Core.Exceptions;
using Movies.Data.Interfaces;
using Movies.Services.Models.Actors;
using Movies.Services.Models.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Movies.Services.Services.Movies
{
    public class MovieService : IMovieService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Movie> _movieRepository;
        private readonly IRepository<Cinema> _cinemaRepository;
        private readonly IRepository<Actor> _actorRepository;
        private readonly ILogger<MovieService> _logger;

        public MovieService(
            IMapper mapper,
            IRepository<Movie> movieRepository,
            IRepository<Cinema> cinemaRepository,
            IRepository<Actor> actorRepository,
            ILogger<MovieService> logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _movieRepository = movieRepository ?? throw new ArgumentNullException(nameof(movieRepository));
            _cinemaRepository = cinemaRepository ?? throw new ArgumentNullException(nameof(cinemaRepository));
            _actorRepository = actorRepository ?? throw new ArgumentNullException(nameof(actorRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IList<MovieListModel>> GetAllAsync(int cinemaId)
        {
            try
            {
                var movies = await _movieRepository.GetAllAsync(query => query
                    .Where(movie => movie.Cinema.Id == cinemaId)
                    .Include(movie => movie.Actors)
                        .ThenInclude(actor => actor.Photos)
                    .Include(movie => movie.Photos
                        .Where(photo => photo.Deleted == false)));

                var moviesList = _mapper.Map<IList<MovieListModel>>(movies);

                return moviesList;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);

                throw new BaseException($"Failed to get all movies",
                    ExceptionType.ServerError, HttpStatusCode.InternalServerError);
            }
        }

        public async Task<IList<ActorListModel>> GetAllActorsAsync(int movieId)
        {
            try
            {
                var movie = await _movieRepository.GetAsync(query => query
                    .Where(movie => movie.Id == movieId)
                    .Include(movie => movie.Actors
                        .Where(actor => actor.Deleted == false)));

                var actors = movie.Actors;

                var actorsList = _mapper.Map<IList<ActorListModel>>(actors);

                return actorsList;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);

                throw new BaseException($"Failed to get all movies actors",
                    ExceptionType.ServerError, HttpStatusCode.InternalServerError);
            }
        }

        public async Task<MovieModel> GetAsync(int cinemaId, int movieId)
        {
            var movie = await _movieRepository.GetAsync(query => query
                .Where(movie => movie.Id == movieId)
                .Where(movie => movie.CinemaId == cinemaId)
                .Include(movie => movie.Actors)
                    .ThenInclude(actor => actor.Photos)
                .Include(movie => movie.Photos
                    .Where(photo => photo.Deleted == false)));

            if (movie == null)
                throw new BaseException($"Movie with id {movieId} not found!", ExceptionType.ServerError,
                    HttpStatusCode.NotFound);

            var movieModel = _mapper.Map<MovieModel>(movie);

            return movieModel;
        }

        public async Task<MovieModel> Create(int cinemaId, MovieCreateModel movieCreateModel)
        {
            try
            {
                var cinema = await _cinemaRepository.GetAsync(query => query
                    .Where(c => c.Id == cinemaId));

                if (cinema == null)
                    throw new BaseException($"Cinema with id {cinemaId} not found!", ExceptionType.NotFound, HttpStatusCode.NotFound);

                var selectedActorIds = movieCreateModel.ActorIds;

                var actors = await _actorRepository.GetAllAsync(query => query
                        .Where(actor => selectedActorIds.Contains(actor.Id)));

                var movie = PrepareMovie(movieCreateModel);

                movie.Cinema = cinema;
                movie.CinemaId = cinemaId;
                movie.Actors = actors.ToList();

                await _movieRepository.InsertAsync(movie);

                var movieModel = _mapper.Map<MovieModel>(movie);

                return movieModel;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error creating new movie, with exception message: {Message}", e.Message);

                if (e is BaseException) throw;
                throw new BaseException($"Failed to create movie", ExceptionType.ServerError,
                    HttpStatusCode.InternalServerError);
            }
        }

        public async Task<MovieModel> Update(int cinemaId, int movieId, MovieCreateModel movieUpdateModel)
        {
            try
            {
                var movie = await _movieRepository.GetAsync(query => query
                    .Where(movie => movie.Id == movieId)
                    .Where(movie => movie.CinemaId == cinemaId));

                if (movie == null)
                    throw new BaseException($"Movie with id: {movieId} does not exist",
                        ExceptionType.NotFound, HttpStatusCode.NotFound);

                var selectedActorIds = movieUpdateModel.ActorIds;

                var actors = await _actorRepository.GetAllAsync(query => query
                        .Where(actor => selectedActorIds.Contains(actor.Id)));

                movie.Actors = actors.ToList();

                _mapper.Map(movieUpdateModel, movie);

                _movieRepository.Update(movie);

                var movieModel = _mapper.Map<MovieModel>(movie);

                return movieModel;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);

                if (e is BaseException) throw;
                throw new BaseException($"Failed to update movie with id: {movieId}!",
                    ExceptionType.ServerError, HttpStatusCode.InternalServerError);
            }
        }

        public async Task<MovieModel> Delete(int cinemaId, int movieId)
        {
            try
            {
                var movie = await _movieRepository.GetAsync(query => query
                    .Where(movie => movie.Id == movieId)
                    .Where(movie => movie.CinemaId == cinemaId));

                _movieRepository.Delete(movie);

                return _mapper.Map<MovieModel>(movie);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);

                if (e is BaseException) throw;
                throw new BaseException($"Failed to update movie with id: {movieId}!",
                    ExceptionType.ServerError, HttpStatusCode.InternalServerError);
            }
        }

        private Movie PrepareMovie(MovieCreateModel movieCreateModel)
        {
            var movie = _mapper.Map<Movie>(movieCreateModel);
            //add authContextService to get user tracing later!
            movie.InsertDate = DateTime.UtcNow;
            movie.UpdateDate = DateTime.UtcNow;
            return movie;
        }
    }
}
