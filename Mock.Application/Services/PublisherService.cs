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
    public class PublisherService : IPublisherService
    {
        private readonly IUnitofWork _unitofwork;
        private readonly IMapper _mapper;

        public PublisherService(IUnitofWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetPublisherDto>> GetAllPublisher()
        {
            IEnumerable<Publisher> publishers = await _unitofwork.publisherRepository.GetAllAsync();

            IEnumerable<GetPublisherDto> result = _mapper.Map<IEnumerable<GetPublisherDto>>(publishers);

            return result;
        }
        public async Task<GetPublisherDto?> GetPublisherById(int id)
        {
            Publisher? publisher = await _unitofwork.publisherRepository.GetAsync(id);

            var result = _mapper.Map<GetPublisherDto>(publisher);

            return result;
        }

        public async Task<GetPublisherDto> CreatePublisher(CreatePublisherDto item)
        {
            var publisher = await _unitofwork.publisherRepository.GetAsync(x => x.Name == item.Name);

            if(publisher is not null && publisher.Any())
            {
                throw new ApplicationException($"Publisher with name : {item.Name} already exist.");
            }

            Publisher pubItem = _mapper.Map<Publisher>(item);

            await _unitofwork.publisherRepository.AddAsync(pubItem);
            await _unitofwork.SaveChangesAsync();

            GetPublisherDto result = _mapper.Map<GetPublisherDto>(pubItem);

            return result;
        }
    }
}
