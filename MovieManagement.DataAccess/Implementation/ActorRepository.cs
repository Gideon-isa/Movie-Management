using Microsoft.EntityFrameworkCore;
using MovieManagement.DataAccess.Context;
using MovieManagement.Domain.Entities;
using MovieManagement.Domain.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MovieManagement.DataAccess.Implementation
{
    public class ActorRepository : GenericRepository<Actor>, IActorRepository
    {
        public ActorRepository(MovieManagementDbContext context) : base(context) { }

        
        public async Task<IEnumerable<Actor>> GetActorsWithMovies()
        {
            var actorsWithMovies = await _context.Actors.Include(u => u.Movies).ToListAsync();
            return actorsWithMovies;
        }
    }
}
