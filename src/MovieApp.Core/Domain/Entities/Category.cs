using MovieApp.Core.Common;
using System;
using System.Collections.Generic;

namespace MovieApp.Core.Domain.Entities
{
    public class Category : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Movie> Movies { get; set; } = new List<Movie>();
    }
}
