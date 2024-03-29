﻿using Movies.Core.Domain.Common;
using System.Collections.Generic;

namespace Movies.Core.Domain
{
    public class Hall : BaseEntity, ISoftDeletedEntity
    {
        public int CinemaId { get; set; }
        public string Name{ get; set; }
        public string HallNumber{ get; set; }
        public int NumberOfRows{ get; set; }
        public bool Has3D { get; set; }
        public bool Deleted{ get; set; }

        public Cinema Cinema{ get; set; }
        public List<MovieTime> MovieTimes { get; set; }
        public List<Row> Rows { get; set; }
    }
}
