using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mock.API.Services.Interfaces;
using Mock.Application.DTOValidators;
using Mock.Application.Models;
using Mock.Domain.Entities;
using Mock.Domain.Interface;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Mock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController : ControllerBase
    {        
        private readonly IVideoGameService _videoGameService;

        public VideoGameController(IVideoGameService videoGameService)
        {
            _videoGameService = videoGameService;
        }

        [HttpGet]
        public async Task<ActionResult<List<VideoGameDto>>> Get()
        {
            var videoGameList = await _videoGameService
                .GetAllVideoGamesAsync();            
            return Ok(videoGameList);   
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VideoGameDto>> GetById(int id)
        {
            var videoGame = await _videoGameService
                .GetVideoGameById(id);

            if (videoGame is null)
                return NotFound();

            return Ok(videoGame);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateVideoGameDto item)
        {
            //Validate DTO
            CreateVideoGameDtoValidator validator = new CreateVideoGameDtoValidator();

            var result = await validator.ValidateAsync(item);

            if(!result.IsValid)
            {
                throw new FluentValidation.ValidationException(result.Errors);
            }

            var videoGame = await _videoGameService.CreateVideoGame(item);
            return Created(nameof(GetById), videoGame);
            
        }
    }
}
