using System;
using System.ComponentModel.DataAnnotations;

namespace my_portfolio_project.Models.DTOs
{
    public class UserDto
    {
        [Required]
        [MaxLength(10)]
        public required string UserName { get; set; }

        public int id { get; set; }

        public int CustomerId { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}
