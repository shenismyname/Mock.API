using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mock.API.DTO;
using Mock.API.Services.Interfaces;
using Mock.Domain.DTOs;
using Mock.Domain.Entities;
using Mock.Domain.Interface;
using System.Runtime.CompilerServices;

namespace Mock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController : ControllerBase
    {
        private readonly IVideoGameRepository _videoGameRepository;
        private readonly IPublisherRepository _publisherRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IVideoGameService _videoGameService;

        public VideoGameController(IVideoGameRepository videoGameRepository,
            IVideoGameService videoGameService,
            IPublisherRepository publisherRepository,
            IGenreRepository genreRepository)
        {
            _videoGameRepository = videoGameRepository;
            _videoGameService = videoGameService;
            _publisherRepository = publisherRepository;
            _genreRepository = genreRepository;
        }

        [HttpGet]
        public async Task<ActionResult<VideoGameDto>> Get()
        {
            var videoGameList = await _videoGameRepository
                .GetAllAsync();
            var result = await _videoGameService.GetAllVideoGamesAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateVideoGameDto item)
        {
            // Check if video game name exist
            var game = await _videoGameRepository.GetAsync(x => x.Title == item.Title);

            if (game != null && game.Any())
            {
                return BadRequest();
            }

            // Check if publisher exist
            var publisher = await _publisherRepository.GetAsync(item.PublisherId);

            if (publisher == null)
                return BadRequest();


            // Check if genre exist
            var genreList = new List<Genre>();
            if (item.GenreList is not null && item.GenreList.Any())
            {
                var genre = await _genreRepository.GetAsync(x => item.GenreList.Any(y => y == x.Id));

                if (item.GenreList.Count() != genre.Count())
                    return BadRequest();

                genreList = genre.ToList();
            }

            VideoGame vg = new VideoGame
            {
                Title = item.Title,
                PublisherId = item.PublisherId,
                Platform = item.Platform,
                GenreList = genreList
            };            

            await _videoGameRepository.AddAsync(vg);            

            return Created();
        }
    }
}
