using Microsoft.AspNetCore.Mvc;
using Services;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Entities;
//using (StreamReader reader = System.IO.File.OpenText("M:\\web api\\MyProject\\WebApplication1\\WebApplication1\\Users.txt")) ;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OurStore2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;

        string filePath = "M:\\web api\\MyProject\\WebApplication1\\WebApplication1\\Users.txt";

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        //password
        [HttpPost]
        [Route("Password")]
        public IActionResult Post([FromQuery] string Password)
        {
            int checkPassword = _userService.Post(Password);
            return checkPassword >= 3 ? Ok(checkPassword) : BadRequest(checkPassword);
        }

        //loginnnnn
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<User>> Post([FromQuery] string Email, string Password)
        {
            User checkUser =await _userService.Post(Email,Password);
            return checkUser != null ? Ok(checkUser) : NoContent();

        }

        // POST api/ add user
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] User user)
        {
            User newUser = await _userService.Post(user);
            if(newUser == null)
                return BadRequest();
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        // PUT api/5
        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, [FromBody] User userToUpdate)
        {
            User newU = await _userService.Put(Id, userToUpdate);
            return newU == null ? BadRequest() : Ok();
        }

    
        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            User checkUser = _userService.Get(id);
            return checkUser != null ? Ok(checkUser) : NoContent();
        }

        // DELETE api/<UserController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
