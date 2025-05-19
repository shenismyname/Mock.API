using Mock.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock.Application.Services.Interfaces
{
    public interface IPublisherService
    {
        public Task<IEnumerable<GetPublisherDto>> GetAllPublisher();
        public Task<GetPublisherDto?> GetPublisherById(int id);
        public Task<GetPublisherDto> CreatePublisher(CreatePublisherDto item);
    }
}
