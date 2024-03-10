using System;
namespace my_portfolio_project.Models.DTOs
{
    public class NewUserDto
    {
        public required string UserName { get; set; }
        public required int CustomerId { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}

