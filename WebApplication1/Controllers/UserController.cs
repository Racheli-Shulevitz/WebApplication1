using Microsoft.AspNetCore.Mvc;
using Services;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Entities;
using AutoMapper;
using DTO;
//using (StreamReader reader = System.IO.File.OpenText("M:\\web api\\MyProject\\WebApplication1\\WebApplication1\\Users.txt")) ;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OurStore2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;
        IMapper mapper;
        private readonly ILogger<UserController> logger;
        //string filePath = "M:\\web api\\MyProject\\WebApplication1\\WebApplication1\\Users.txt";

        public UserController(IUserService userService, IMapper _mapper, ILogger<UserController> _logger)
        {
            _userService = userService;
            mapper = _mapper;
            logger = _logger;
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
            logger.LogCritical($"Login Attempted with User name,{Email} and password {Password}", Email, Password);

            User checkUser =await _userService.Post(Email,Password);
            return checkUser != null ? Ok(checkUser) : NoContent();


        }

        // POST api/ add user
        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] AddUserDTO user)
        {
            User? newUser = await _userService.Post(mapper.Map<AddUserDTO, User>(user));
            if (newUser == null)
                return BadRequest();
            return CreatedAtAction(nameof(Get), new { id = newUser.Id }, mapper.Map<User, UserDTO>(newUser));
        }

        // PUT api/5
        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, [FromBody] AddUserDTO userToUpdate)
        {
            User newU = await _userService.Put(Id, mapper.Map<AddUserDTO, User>(userToUpdate));
            return newU == null ? BadRequest() : Ok();
        }
        //
    
        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> Get(int id)
        {
            User checkUser = await _userService.Get(id);
            UserDTO userDTO =  mapper.Map<User, UserDTO>(checkUser);
            //return userDTO != null ? Ok(userDTO) : NoContent();
          //  if(userDTO)
          //return checkUser != null ?  Ok(userDTO):  NoContent();



            if (userDTO != null)
                return Ok(userDTO);
            else
                return NoContent();

        }

        // DELETE api/<UserController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
