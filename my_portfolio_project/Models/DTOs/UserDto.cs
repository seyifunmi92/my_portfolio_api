using System;

namespace my_portfolio_project.Models.DTOs
{
    public class UserDto
    {
        public required string UserName { get; set; }
        public int UserId { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
