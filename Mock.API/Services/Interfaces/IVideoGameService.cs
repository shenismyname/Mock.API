using Mock.Domain.DTOs;

namespace Mock.API.Services.Interfaces
{
    public interface IVideoGameService
    {
        public Task<IEnumerable<VideoGameDto>> GetAllVideoGamesAsync();        
    }
}
