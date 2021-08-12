using MovieApp.Core.Common;
using System;
using System.Collections.Generic;

namespace MovieApp.Core.Domain.Entities
{
    public class Movie : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Timestamp { get; set; }
        public Category Category { get; set; }
        public List<Actor> Actors { get; set; } = new List<Actor>();
    }
}
