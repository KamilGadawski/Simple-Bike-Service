﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAPI.Entities
{
    public class Bike
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Brand { get; set; }

        [Required]
        [MaxLength(2)]
        public int Size { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        [MaxLength(50)]
        public string Model { get; set; }

        public Guid CustomerID { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime AddedBike { get; set; }

        public ICollection<Customer> Repairs { get; set; } = new List<Customer>();
    }
}
