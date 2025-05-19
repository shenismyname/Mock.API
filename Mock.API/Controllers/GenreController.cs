using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mock.Application.Models;
using Mock.Application.Services.Interfaces;
using Mock.Domain.Entities;
using Mock.Domain.Interface;
using Mock.Repository.Repositories;

namespace Mock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreServices _genreServices;
        public GenreController(IGenreServices genreServices)
        {
            _genreServices = genreServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetGenreDto>>> Get()
        {
            var genreList = await _genreServices.GetAllGenres();
            return Ok(genreList);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<GetGenreDto>> GetById(int Id)
        {
            var genre = await _genreServices.GetGenreById(Id);

            if (genre == null)
                return NotFound();

            return Ok(genre);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGenreDto item)
        {

            GetGenreDto genre = await _genreServices.CreateGenre(item);
            return Created(nameof(GetById), genre);

        }
    }
}
