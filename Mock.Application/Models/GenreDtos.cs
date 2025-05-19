using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock.Application.Models
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
