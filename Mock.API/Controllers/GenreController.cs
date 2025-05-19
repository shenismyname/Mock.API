using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mock.API.DTO;
using Mock.Domain.Entities;
using Mock.Domain.Interface;
using Mock.Repository.Repositories;

namespace Mock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreRepository _genreRepository;
        public GenreController(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetGenreDto>>> Get()
        {
            var genre = await _genreRepository.GetAllAsync();
            var dto = genre.Select(x => new GetGenreDto
            {
                Id = x.Id,
                Name = x.name
            });
            return Ok(dto);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<GetGenreDto>> Get(int Id)
        {
            var genre = await _genreRepository.GetAsync(Id);

            if (genre == null)
                return NotFound();

            var dto = new GetPublisherDto
            {
                Id = genre.Id,
                Name = genre.name
            };
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGenreDto item)
        {
            var genre = await _genreRepository.GetAsync(x => x.name == item.Name);

            if (genre != null && genre.Count() > 0)
                return BadRequest();

            var pubItem = new Genre
            {
                name = item.Name
            };

            await _genreRepository.AddAsync(pubItem);

            return Created();
        }
    }
}
