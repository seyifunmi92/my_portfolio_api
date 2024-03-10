using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using my_portfolio_project.Data;
using my_portfolio_project.Models;
using my_portfolio_project.Models.DTOs;

namespace my_portfolio_project.Controllers
{
    // [Route("api/[controller]/user")]
    [Route("api/user")]

    [ApiController]
    public class Mydata : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<UserDto>> GetAllUserAccount()
        {
            var dataList = UserRepo.userRepo;

            return Ok(dataList);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UserDto> GetUserById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var dataList = UserRepo.userRepo;
            var response = dataList!.FirstOrDefault(x => x.id == id)!;

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<UserDto> CreateNewUser([FromBody] UserDto _newUser)
        {
            var dataList = UserRepo.userRepo;
            if (_newUser == null)
            {
                return BadRequest(_newUser);
            }

            if (_newUser.id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            for (var i = 0; i < dataList.Count; i++)
            {
                if (_newUser.id == dataList[i].id)
                {
                    return BadRequest(_newUser);
                }
            }


            _newUser.id = dataList.OrderByDescending(x => x.id).FirstOrDefault()!.id + 1;
            dataList.Add(_newUser);
            return Ok(_newUser);
        }
    }
}
