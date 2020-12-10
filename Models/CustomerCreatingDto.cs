using System;

namespace ServiceAPI.Models
{
    public class CustomerCreatingDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string TelephoneNumber { get; set; }
        public DateTime CustomerAdd { get; set; }
    }
}
