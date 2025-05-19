using AutoMapper;
using Mock.Application.Models;
using Mock.Application.Services.Interfaces;
using Mock.Domain.Entities;
using Mock.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock.Application.Services
{
    public class GenreService : IGenreServices
    {
        private readonly IUnitofWork _unitofwork;
        private readonly IMapper _mapper;

        public GenreService(IUnitofWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetGenreDto>> GetAllGenres()
        {
            IEnumerable<Genre> genreList = await _unitofwork.genreRepository.GetAllAsync();

            IEnumerable<GetGenreDto> result = _mapper.Map<IEnumerable<GetGenreDto>>(genreList);

            return result;

        }
        public async Task<GetGenreDto?> GetGenreById(int id)
        {
            Genre? genre = await _unitofwork.genreRepository.GetAsync(id);            
            GetGenreDto? result = _mapper.Map<GetGenreDto?>(genre);

            return result;
        }
        public async Task<GetGenreDto> CreateGenre(CreateGenreDto item)
        {
            var genre = await _unitofwork.genreRepository.GetAsync(x => x.name == item.Name);

            if(genre != null && genre.Any())
            {
                throw new ApplicationException($"Genre with name '{item.Name}' already exists.");
            }

            Genre genreItem = _mapper.Map<Genre>(item);

            await _unitofwork.genreRepository.AddAsync(genreItem);
            await _unitofwork.SaveChangesAsync();

            var result = _mapper.Map<GetGenreDto>(genreItem);

            return result;
        }
    }
}
