using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAPI.Entities
{
    public class Customer
    {
        [Key]
        public Guid Id{ get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Surname { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email {get; set; }

        [Required]
        public int TelephoneNumber { get; set; }

        [ForeignKey("BikeId")]
        public Bike Bike { get; set; }
        public Guid BikeId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateTimeAdd { get; set; }
    }
}
