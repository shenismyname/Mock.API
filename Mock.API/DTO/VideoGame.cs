using Mock.Domain.Entities;

namespace Mock.API.DTO
{
    public class CreateVideoGameDto
    {
        public string Title { get; set; } = null!;
        public string Platform { get; set; } = null!;
        public int PublisherId { get; set; } // FK        
        public List<int>? GenreList { get; set; } //NP 
    }
}
