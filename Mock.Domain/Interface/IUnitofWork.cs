using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock.Domain.Interface
{
    public interface IUnitofWork : IDisposable
    {
        IVideoGameRepository videoGameRepository { get; }
        IGenreRepository genreRepository { get;  }
        IPublisherRepository publisherRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
