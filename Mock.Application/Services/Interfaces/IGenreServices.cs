using Mock.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock.Application.Services.Interfaces
{
    public interface IGenreServices
    {
        public Task <IEnumerable<GetGenreDto>> GetAllGenres();
        public Task<GetGenreDto?> GetGenreById(int id);
        public Task<GetGenreDto> CreateGenre(CreateGenreDto item);
    }
}
