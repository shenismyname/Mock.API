using Microsoft.EntityFrameworkCore;
using Mock.API.Services.Interfaces;
using Mock.Domain.DTOs;
using Mock.Domain.Interface;

namespace Mock.API.Services
{
    public class VideoGameService : IVideoGameService
    {
        private readonly IVideoGameRepository _videoGameRepository;

        public VideoGameService(IVideoGameRepository videoGameRepository)
        {
            _videoGameRepository = videoGameRepository;
        }
        public async Task<IEnumerable<VideoGameDto>> GetAllVideoGamesAsync()
        {
            var gamesQuery = _videoGameRepository.GetAllVideoGamesInformation();
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
    }
}
