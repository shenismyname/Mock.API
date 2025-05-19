using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock.Domain.Entities
{
    public class VideoGame : BaseEntity
    {        
        public string Title { get; set; } = null!;
        public string Platform { get; set; } = null!;
        public int PublisherId { get; set; } // FK

        public Publisher? Publisher { get; set; } // NP
        public List<Genre>? GenreList { get; set; } //NP
    }
}
