﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MovieManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.DataAccess.Context
{
    public class MovieManagementDbContext : DbContext
    {
        public MovieManagementDbContext(DbContextOptions<MovieManagementDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet <Biography> Biographies { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Call the base method to apply default configurations
            base.OnModelCreating(modelBuilder);

            var actors = new List<Actor>()
            {
                new Actor { Id = 1, FirstName = "Chuck", LastName = "Norris"},
                new Actor { Id = 2, FirstName = "Jane", LastName = "Doe"},
                new Actor { Id = 3, FirstName = "Van", LastName = "Damme"}
            };
            modelBuilder.Entity<Actor>().HasData(actors);

            var movies = new List<Movie>()
            {
                new Movie { Id = 1, Name = "Wakanda Forever", Description = "Box office is coming", ActorId =1},
                new Movie { Id = 2, Name = "Wakanda Forever", Description = "Box office is coming", ActorId =2},
                new Movie { Id = 3, Name = "Spiderman", Description = "Sky Scrappers be warned", ActorId =1},
                new Movie { Id = 4, Name = "Matrix", Description = "Blue or Red Pill", ActorId =3},
            };

            modelBuilder.Entity<Movie>().HasData(movies);
        }
    }
}
