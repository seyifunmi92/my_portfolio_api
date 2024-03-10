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
    //  [ApiController]
    public class Mydata : ControllerBase
    {
        [HttpGet(Name = "GetAllUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<UserDto>> GetAllUserAccount()
        {
            var dataList = UserRepo.userRepo;

            return Ok(dataList);
        }

        [HttpGet("{id:int}", Name = "GetUserbyId")]
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

        [HttpPost(Name = "CreateUser")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<UserDto> CreateNewUser([FromBody] UserDto _newUser)
        {
            var dataList = UserRepo.userRepo;

            //check for model state validations
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //check if username provided is unique
            if (
                dataList.FirstOrDefault(x => x.UserName.ToLower() == _newUser.UserName.ToLower())
                != null
            )
            {
                ModelState!.AddModelError("Exception", "Username already exists");
                return BadRequest(ModelState);
            }

            //check if username is null
            if (_newUser == null)
            {
                return BadRequest(_newUser);
            }

            //check if userid is not 0
            if (_newUser.id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            //check if userID exists
            if (dataList.FirstOrDefault(x => x.id == _newUser.id) != null)
            {
                return BadRequest(_newUser);
            }

            //on success call
            _newUser.id = dataList.OrderByDescending(x => x.id).FirstOrDefault()!.id + 1;
            dataList.Add(_newUser);
            return CreatedAtRoute("GetUserbyId", new { id = _newUser.id }, _newUser);
        }

        [HttpDelete("{id:int}", Name = "DeleteUser")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<UserDto> DeleteUserById(int? id)
        {
            var dataList = UserRepo.userRepo;

            if (id == null || id.ToString() == "")
            {
                ModelState.AddModelError("Exception", "id field must not be empty");

                return BadRequest(ModelState);
            }

            var item = dataList.FirstOrDefault(x => x.id == id);

            if (item == null)
            {
                ModelState.AddModelError("Exception", "This customer does not exist");
                return NotFound(ModelState);
            }

            for (var i = 0; i < dataList.Count; i++)
            {
                if (id == dataList[i].id)
                {
                    dataList.RemoveAt(i);
                }
            }

            return Ok();
        }
    }
}
