using Mock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock.Domain.Interface
{
    public interface IVideoGameRepository : IBaseRepository<VideoGame>
    {
        public IQueryable<VideoGame> GetAllVideoGamesInformation();
    }
}
