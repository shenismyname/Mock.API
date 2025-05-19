using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mock.Application.Models;
using Mock.Application.Services.Interfaces;
using Mock.Domain.Entities;
using Mock.Domain.Interface;

namespace Mock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetPublisherDto>>> Get()
        {
            var publisher = await _publisherService.GetAllPublisher();
            return Ok(publisher);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<GetPublisherDto>> GetById(int Id)
        {
            var publisher = await _publisherService.GetPublisherById(Id);

            if (publisher == null)
                return NotFound();

            return Ok(publisher);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePublisherDto item)
        {
            var publisher = await _publisherService.CreatePublisher(item);
            return Created(nameof(GetById), publisher);
        }

    }
}
