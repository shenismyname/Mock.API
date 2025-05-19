using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock.Domain.DTOs
{
    public class VideoGameDto
    {
        public int id { get; set; }
        public string Title { get; set; } = null!;
        public string Platform { get; set; } = null!;
        public string PublisherName { get; set; } = null!;
        public IEnumerable<string>? GenreList { get; set; }
    }
}
