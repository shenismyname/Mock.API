using AutoMapper;
using Mock.Application.Models;
using Mock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock.Application.Mappers
{
    public class GetGenreDtoGenreMapper : Profile
    {
        public GetGenreDtoGenreMapper()
        {
            CreateMap<GetGenreDto, Genre>().ReverseMap();
        }


    }

    public class CreateGenreDtoGenreMapper : Profile
    {
        public CreateGenreDtoGenreMapper()
        {
            CreateMap<CreateGenreDto, Genre>().ReverseMap();
        }
    }
}