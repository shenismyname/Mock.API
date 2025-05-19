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
    public class PublisherRepository: BaseRepository<Publisher>, IPublisherRepository
    {
        private readonly MockDbContext _dbcontext;

        public PublisherRepository(MockDbContext dbContext) : base(dbContext)
        {
            _dbcontext = dbContext;
        }
    }
}
