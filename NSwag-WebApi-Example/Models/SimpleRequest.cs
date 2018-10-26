using System;
using System.ComponentModel.DataAnnotations;

namespace NSwag_WebApi_Example.Models
{
    public class SimpleRequest
    {
        [Required]
        public Guid ID { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }
    }
}
