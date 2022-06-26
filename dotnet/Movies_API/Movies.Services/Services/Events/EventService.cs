﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Movies.Core.Domain;
using Movies.Core.Exceptions;
using Movies.Data.Interfaces;
using Movies.Services.Models.Events;
using System.Net;

namespace Movies.Services.Services.Events
{
    public class EventService : IEventService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Event> _eventRepository;
        private readonly IRepository<Cinema> _cinemaRepository;
        private readonly ILogger<EventService> _logger;

        public EventService(
            IMapper mapper,
            IRepository<Event> EventRepository,
            ILogger<EventService> logger, 
            IRepository<Cinema> cinemaRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _eventRepository = EventRepository ?? throw new ArgumentNullException(nameof(EventRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _cinemaRepository = cinemaRepository ?? throw new ArgumentNullException(nameof(cinemaRepository));
        }

        public async Task<EventModel> GetAsync(int EventId)
        {
            var Event = await _eventRepository.GetAsync(query => query
                .Where(Event => Event.Id == EventId));

            if (Event == null)
                throw new BaseException($"Event with id {EventId} not found!", ExceptionType.ServerError,
                    HttpStatusCode.NotFound);

            var EventModel = _mapper.Map<EventModel>(Event);

            return EventModel;
        }

        public async Task<IList<EventListModel>> GetAllAsync()
        {
            try
            {
                var Events = await _eventRepository.GetAllAsync(query => query);

                var EventsList = _mapper.Map<IList<EventListModel>>(Events);

                return EventsList;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);

                throw new BaseException($"Failed to get all Events",
                    ExceptionType.ServerError, HttpStatusCode.InternalServerError);
            }
        }

        public async Task<EventModel> Create(int cinemaId, EventCreateModel eventCreateModel)
        {
            try
            {
                var cinema = await _cinemaRepository.GetAsync(query => query
                    .Where(c => c.Id == cinemaId));

                if (cinema == null)
                    throw new BaseException($"Cinema with id {cinemaId} not found!", ExceptionType.NotFound, HttpStatusCode.NotFound);

                var @event = PrepareEvent(eventCreateModel);
                @event.Cinema = cinema;
                @event.CinemaId = cinemaId;

                await _eventRepository.InsertAsync(@event);

                var movieModel = _mapper.Map<EventModel>(@event);

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

        public async Task<EventModel> Update(int EventId, EventCreateModel EventUpdateModel)
        {
            try
            {
                var Event = await _eventRepository.GetAsync(query => query
                    .Where(Event => Event.Id == EventId));

                if (Event == null)
                    throw new BaseException($"Event with id: {EventId} does not exist",
                        ExceptionType.NotFound, HttpStatusCode.NotFound);

                _mapper.Map(EventUpdateModel, Event);

                _eventRepository.Update(Event);

                var EventModel = _mapper.Map<EventModel>(Event);

                return EventModel;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);

                if (e is BaseException) throw;
                throw new BaseException($"Failed to update Event with id: {EventId}!",
                    ExceptionType.ServerError, HttpStatusCode.InternalServerError);
            }
        }

        public async Task<EventModel> Delete(int EventId)
        {
            try
            {
                var Event = await _eventRepository.GetAsync(query => query
                    .Where(Event => Event.Id == EventId));

                _eventRepository.Delete(Event);

                return _mapper.Map<EventModel>(Event);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);

                if (e is BaseException) throw;
                throw new BaseException($"Failed to update Event with id: {EventId}!",
                    ExceptionType.ServerError, HttpStatusCode.InternalServerError);
            }
        }

        private Event PrepareEvent(EventCreateModel EventCreateModel)
        {
            var Event = _mapper.Map<Event>(EventCreateModel);
            Event.InsertDate = DateTime.UtcNow;
            Event.UpdateDate = DateTime.UtcNow;
            return Event;
        }
    }
}