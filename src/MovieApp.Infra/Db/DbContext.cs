using MovieApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieApp.Infra.Db
{
    public class DbContext
    {
        public List<Actor> Actors { get; set; }
        public List<Movie> Movies { get; set; }
        public List<Category> Categories { get; set; }

        public DbContext()
        {
            Actors = GenerateActors();
            Categories = GenerateCategories();
            Movies = GenerateMovies(Actors, Categories);

            foreach(var category in Categories)
            {
                category.Movies = Movies.Where(m => m.Category.Id == category.Id).ToList();
            }
        }

        private static List<Actor> GenerateActors()
        {
            List<Actor> result = new();
            for (int i = 0; i < 1000; i++)
            {
                result.Add(new Actor()
                {
                    Id = Guid.NewGuid(),
                    Name = $"Actor {i + 1}"
                });
            }
            return result;
        }

        private static List<Movie> GenerateMovies(List<Actor> actors, List<Category> categories)
        {
            var randow = new Random();
            List<Movie> result = new();

            for (int i = 0; i < 20000; i++)
            {
                result.Add(new Movie()
                {
                    Id = Guid.NewGuid(),
                    Name = $"Movie {i + 1}",
                    Timestamp = DateTime.UtcNow,
                    Actors = actors.Skip(randow.Next(0, 999)).Take(randow.Next(0, 999)).ToList(),
                    Category = categories.ElementAt(randow.Next(0, 49))
                });
            }

            return result;
        }

        private static List<Category> GenerateCategories()
        {
            List<Category> result = new();

            for (int i = 0; i < 20000; i++)
            {
                result.Add(new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = $"Category {i + 1}"
                });
            }

            return result;
        }
    }
}
