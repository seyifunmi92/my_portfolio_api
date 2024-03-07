using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using my_portfolio_project.Data;
using my_portfolio_project.Models;
using my_portfolio_project.Models.DTOs;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace my_portfolio_project.Controllers
{
    [Route("api/[controller]/user")]
    [ApiController]
    public class Mydata : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetAllUserAccount()
        {
            var dataList = UserRepo.userRepo;

            return Ok(dataList);
        }

        [HttpGet("{id:int}")]
        public ActionResult<UserDto> GetUserById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var dataList = UserRepo.userRepo;
            var response = dataList!.FirstOrDefault(x => x.UserId == id)!;

            if (response == null)
            {
                return NotFound();

            }

            return Ok(response);


        }
    }
}
