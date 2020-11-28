using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAPI.Models
{
    public class BikeDto
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public int Size { get; set; }
        public string Description { get; set; }
        public string Model { get; set; }
        public string AddedBikeAgo { get; set; }
    }
}
