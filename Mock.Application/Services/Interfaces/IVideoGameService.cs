using Mock.Application.Models;

namespace Mock.API.Services.Interfaces
{
    public interface IVideoGameService
    {
        public Task<IEnumerable<VideoGameDto>> GetAllVideoGamesAsync();
        public Task<VideoGameDto?> GetVideoGameById(int id);
        public Task<VideoGameDto> CreateVideoGame(CreateVideoGameDto item);
    }
}
