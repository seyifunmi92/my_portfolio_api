using System;
using my_portfolio_project.Models.DTOs;

namespace my_portfolio_project.Data
{
    public static class UserRepo
    {
        public static List<UserDto> userRepo = new List<UserDto>
        {
            new UserDto
            {
                UserName = "Oluwaseyi",
                id = 1,
                CustomerId = 10,
                CreatedDate = DateTime.Now,
            },
            new UserDto
            {
                UserName = "Aderonke",
                id = 2,
                CustomerId = 40,
                CreatedDate = DateTime.Now,
            },
            new UserDto
            {
                UserName = "Inioluwa",
                id = 3,
                CustomerId = 40,
                CreatedDate = DateTime.Now,
            },
            new UserDto
            {
                UserName = "Adebayo",
                id = 4,
                CustomerId = 1,
                CreatedDate = DateTime.Now,
            },
            new UserDto
            {
                UserName = "Adebayo",
                id = 5,
                CustomerId = 1,
                CreatedDate = DateTime.Now,
            },
            new UserDto
            {
                UserName = "Adebayo",
                id = 6,
                CustomerId = 1,
                CreatedDate = DateTime.Now,
            },
            new UserDto
            {
                UserName = "Adebayo",
                id = 7,
                CustomerId = 1,
                CreatedDate = DateTime.Now,
            },
            new UserDto
            {
                UserName = "Adebayo",
                id = 8,
                CustomerId = 1,
                CreatedDate = DateTime.Now,
            },
            new UserDto
            {
                UserName = "Adebayo",
                id = 9,
                CustomerId = 1,
                CreatedDate = DateTime.Now,
            },
            new UserDto
            {
                UserName = "Adebayo",
                id = 10,
                CustomerId = 1,
                CreatedDate = DateTime.Now,
            },
        };
    }
}
