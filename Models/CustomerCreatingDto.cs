using System;
using System.ComponentModel.DataAnnotations;

namespace ServiceAPI.Models
{
    public class CustomerCreatingDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Surname { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string TelephoneNumber { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CustomerAdd { get; set; }
    }
}
