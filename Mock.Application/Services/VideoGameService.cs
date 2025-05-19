using Microsoft.EntityFrameworkCore;
using Mock.API.Services.Interfaces;
using Mock.Application.Models;
using Mock.Domain.Entities;
using Mock.Domain.Interface;

namespace Mock.API.Services
{
    public class VideoGameService : IVideoGameService
    {
        private readonly IUnitofWork _unitofwork;     

        public VideoGameService(IUnitofWork unitofwork)
        {
            _unitofwork = unitofwork;
        }
        
        public async Task<IEnumerable<VideoGameDto>> GetAllVideoGamesAsync()
        {
            var gamesQuery = _unitofwork.videoGameRepository.GetAllVideoGamesInformation();
            var result = await gamesQuery.Select(x => new VideoGameDto
            {
                id = x.Id,
                Platform = x.Platform,
                PublisherName = x.Publisher == null ? string.Empty : x.Publisher.Name,
                Title = x.Title,
                GenreList = x.GenreList == null ? new List<string>() : x.GenreList.Select(x => x.name)
            })
            .ToListAsync();

            return result;
        }

        public async Task<VideoGameDto?> GetVideoGameById(int id)
        {
            var gamesQuery = _unitofwork.videoGameRepository.GetAllVideoGamesInformation();
            var videoGame = await gamesQuery.FirstOrDefaultAsync(x => x.Id == id);

            if (videoGame is null)
                return null;

            var result = new VideoGameDto
            {
                id = videoGame.Id,
                Platform = videoGame.Platform,
                PublisherName = videoGame.Publisher == null ? string.Empty : videoGame.Publisher.Name,
                Title = videoGame.Title,
                GenreList = videoGame.GenreList == null ? new List<string>() : videoGame.GenreList.Select(x => x.name)
            };            

            return result;
        }

        public async Task<VideoGameDto> CreateVideoGame(CreateVideoGameDto item)
        {
            // Check if video game name exist
            var game = await _unitofwork.videoGameRepository.GetAsync(x => x.Title == item.Title);

            if (game != null && game.Any())
            {
                throw new ApplicationException($"Video game with title : {item.Title} already exists.");
            }

            // Check if publisher exist
            var publisher = await _unitofwork.publisherRepository.GetAsync(item.PublisherId);

            if (publisher == null)
                throw new ApplicationException($"Publisher with id : {item.PublisherId} does not exists.");


            // Check if genre exist
            var genreList = new List<Genre>();
            if (item.GenreList is not null && item.GenreList.Any())
            {
                var genre = await _unitofwork.genreRepository.GetAsync(x => item.GenreList.Any(y => y == x.name));                
                genreList = genre.ToList();
            }

            VideoGame vg = new VideoGame
            {
                Title = item.Title,
                PublisherId = item.PublisherId,
                Platform = item.Platform,
                GenreList = genreList
            };

            await _unitofwork.videoGameRepository.AddAsync(vg);
            await _unitofwork.SaveChangesAsync();

            var gamesQuery = _unitofwork.videoGameRepository.GetAllVideoGamesInformation();
            var videoGame = await gamesQuery.FirstAsync(x => x.Id == vg.Id);

            var result = new VideoGameDto
            {
                id = videoGame.Id,
                Platform = videoGame.Platform,
                PublisherName = videoGame.Publisher == null ? string.Empty : videoGame.Publisher.Name,
                Title = videoGame.Title,
                GenreList = videoGame.GenreList == null ? new List<string>() : videoGame.GenreList.Select(x => x.name)
            };

            return result;
        }
    }
}
