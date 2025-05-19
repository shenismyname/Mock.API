namespace Mock.API.DTO
{
    public class GetPublisherDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }

    public class CreatePublisherDto
    {
        public string Name { get; set; } = null!;
    }
}
