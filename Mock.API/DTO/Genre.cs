namespace Mock.API.DTO
{
    public class GetGenreDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }

    public class CreateGenreDto
    {
        public string Name { get; set; } = null!;
    }
}
