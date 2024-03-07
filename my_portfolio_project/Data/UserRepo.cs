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
                UserId = 30,
                CustomerId = 10
            },
            new UserDto
            {
                UserName = "Aderonke",
                UserId = 10,
                CustomerId = 40
            },
            new UserDto
            {
                UserName = "Inioluwa",
                UserId = 40,
                CustomerId = 40
            },
            new UserDto
            {
                UserName = "Adebayo",
                UserId = 33,
                CustomerId = 1
            },
            new UserDto
            {
                UserName = "Adebayo",
                UserId = 13,
                CustomerId = 1
            },
            new UserDto
            {
                UserName = "Adebayo",
                UserId = 23,
                CustomerId = 1
            },
            new UserDto
            {
                UserName = "Adebayo",
                UserId = 53,
                CustomerId = 1
            },
            new UserDto
            {
                UserName = "Adebayo",
                UserId = 63,
                CustomerId = 1
            },
            new UserDto
            {
                UserName = "Adebayo",
                UserId = 43,
                CustomerId = 1
            },
            new UserDto
            {
                UserName = "Adebayo",
                UserId = 33,
                CustomerId = 1
            },
        };
    }
}
