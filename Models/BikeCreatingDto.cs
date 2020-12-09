using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAPI.Models
{
    public class BikeCreatingDto
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Size { get; set; }
        public string Description { get; set; }
        public Guid CustomerID { get; set; }
        public DateTime BikeAdd { get; set; }
        
        public BikeCreatingDto()
        {
            this.BikeAdd = DateTime.UtcNow;
        }
    }
}
