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
    public class GetPublisherDtoPublisherMapper : Profile
    {
        public GetPublisherDtoPublisherMapper()
        {
            CreateMap<GetPublisherDto, Publisher>().ReverseMap();
        }
    }

    public class CreatePublisherDtoPublisherMapper : Profile
    {
        public CreatePublisherDtoPublisherMapper()
        {
            CreateMap<CreatePublisherDto, Publisher>().ReverseMap();
        }
    }
}
