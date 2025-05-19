using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock.Domain.Entities
{
    public class Genre : BaseEntity
    {        
        public string name { get; set; } = null!;
    }
}
