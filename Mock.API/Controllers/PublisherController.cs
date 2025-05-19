using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mock.API.DTO;
using Mock.Domain.Entities;
using Mock.Domain.Interface;

namespace Mock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherRepository _publisherRepository;

        public PublisherController(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetPublisherDto>>> Get()
        {
            var publisher = await _publisherRepository.GetAllAsync();
            var dto = publisher.Select(x => new GetPublisherDto
            {
                Id = x.Id,
                Name = x.Name
            });
            return Ok(dto);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<GetPublisherDto>> Get(int Id)
        {
            var publisher = await _publisherRepository.GetAsync(Id);

            if (publisher == null)
                return NotFound();

            var dto = new GetPublisherDto
            {
                Id = publisher.Id,
                Name = publisher.Name
            };
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreatePublisherDto item)
        {
            var publisher = await _publisherRepository.GetAsync(x => x.Name == item.Name);

            if (publisher != null && publisher.Count() > 0)
                return BadRequest();

            var pubItem = new Publisher
            {
                Name = item.Name
            };

            await _publisherRepository.AddAsync(pubItem);

            return Created();
        }

    }
}
