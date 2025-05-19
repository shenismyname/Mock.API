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
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        private readonly MockDbContext _dbcontext;
        public GenreRepository(MockDbContext context) : base(context)
        {
            _dbcontext = context;
        }
    }
}
