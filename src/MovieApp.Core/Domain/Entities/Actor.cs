using MovieApp.Core.Common;
using System;

namespace MovieApp.Core.Domain.Entities
{
    public class Actor : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
