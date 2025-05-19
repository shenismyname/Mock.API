using Microsoft.EntityFrameworkCore;
using Mock.Domain.Entities;
using Mock.Domain.Interface;
using Mock.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock.Repository.Repositories
{
    public class VideoGameRepository : BaseRepository<VideoGame>, IVideoGameRepository
    {
        private readonly MockDbContext _dbcontext;
        public VideoGameRepository(MockDbContext context) : base(context)
        {
            _dbcontext = context;
        }

        public IQueryable<VideoGame> GetAllVideoGamesInformation()
        {
            return _dbcontext.VideoGame
                .Include(x => x.Publisher)
                .Include(x => x.GenreList);
        }
    }
}
