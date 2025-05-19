using Microsoft.EntityFrameworkCore;
using Mock.Domain.Interface;
using Mock.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock.Repository.Repositories
{
    public class UnitofWork : IUnitofWork
    {
        private readonly MockDbContext _dbContext;
        public IVideoGameRepository videoGameRepository { get; private set; }
        public IGenreRepository genreRepository { get; private set; }
        public IPublisherRepository publisherRepository { get; private set; }

        public UnitofWork(IVideoGameRepository _videoGameRepository,
            IGenreRepository _genreRepository,
            IPublisherRepository _publisherRepository,
            MockDbContext dbContext)
        {
            videoGameRepository = _videoGameRepository;
            genreRepository = _genreRepository;
            publisherRepository = _publisherRepository;
            _dbContext = dbContext;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
