using ServiceAPI.ValidationAttributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace ServiceAPI.Models
{
    [BrandAndModelBike]
    public class BikeCreatingDto
    {
        [Required]
        [MaxLength(50)]
        public string Brand { get; set; }

        [Required]
        [MaxLength(50)]
        public string Model { get; set; }

        [Required]
        public int Size { get; set; }

        [Required]
        [MaxLength(400)]
        public string Description { get; set; }

        [Required]
        public Guid CustomerID { get; set; }
        public DateTime BikeAdd { get; set; }
    }
}
