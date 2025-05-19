namespace Mock.Application.Models
{
    public class VideoGameDto
    {
        public int id { get; set; }
        public string Title { get; set; } = null!;
        public string Platform { get; set; } = null!;
        public string PublisherName { get; set; } = null!;
        public IEnumerable<string>? GenreList { get; set; }
    }

    public class CreateVideoGameDto
    {
        public string Title { get; set; } = null!;
        public string Platform { get; set; } = null!;
        public int PublisherId { get; set; } // FK        
        public List<string>? GenreList { get; set; } //NP 
    }
}
