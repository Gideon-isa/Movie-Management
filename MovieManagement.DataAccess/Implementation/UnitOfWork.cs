using MovieManagement.DataAccess.Context;
using MovieManagement.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.DataAccess.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        public MovieManagementDbContext _context { get; }
        public UnitOfWork(MovieManagementDbContext context)
        {
            _context = context;
        }


        private IActorRepository _actor;
        private IMovieRepository _movie;
        private IGenreRepository _genre;
        private IBiographyRepository _biography;


        public IActorRepository Actor
        {
            get
            {
                if (_actor == null)
                {
                    _actor =  new ActorRepository(_context);
                }

                return _actor;
            }
            private set { _actor = value; }
        }


        public IMovieRepository Movie
        {
            get
            {
                if (_movie == null)
                {
                    _movie =  new MovieRepository(_context);
                }
                return _movie;
            }
                private set { _movie = value; }
        }

        public IGenreRepository Genre
        {
            get
            {
                if (_genre == null)
                {
                    _genre = new GenreRepository(_context);
                }
                return _genre;
            }
            private set { _genre = value; }
        }



        public IBiographyRepository Biography
        {
            get
            {
                if (_biography == null)
                {
                    _biography =  new BiographyRepository(_context);
                }
                return _biography;
            }
            private set { _biography = value; }
        }


        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }


    }
}
