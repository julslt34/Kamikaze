using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Kamikaze.Repositories;
using Kamikaze.Models;
using System.Collections.Generic;
using Microsoft.Extensions.Hosting;




namespace Kamikaze.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        //public IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
            {
            _userRepository = userRepository;
            }

        // GET: api/<UserController>
        [HttpGet]
            public IActionResult GetAllUsers()
            {
                return Ok(_userRepository.GetAllUsers());
            }

        //GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("GetUserByEmail")]
        public IActionResult GetUserByEmail(string email)
        {
            var user = _userRepository.GetUserByEmail(email);

            if (email == null || user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }


        [HttpPost]
        public IActionResult Post(User user)
        {
            _userRepository.Add(user);
            return CreatedAtAction(
                "GetUserByEmail",
                new { email = user.Email },
                user);
        }


        // POST api/<CategoryController>
        //[HttpPost]
        //public IActionResult Add(Category category)
        //{
        //    _categoryRepository.Add(category);
        //    return CreatedAtAction("Get", new { id = category.Id }, category);
        //}

        // PUT api/<CategoryController>/5
        //[HttpPut("{id}")]
        //public IActionResult Update(int id, Category category)
        //{
        //    _categoryRepository.Update(category);
        //    return Ok(category);
        //}

        // DELETE api/<CategoryController>/5
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    _categoryRepository.Delete(id);
        //    return NoContent();
        //}
    }
    }





//namespace Kamikaze.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UserController : ControllerBase
//    {
//        // GET: api/<UserController>
//        [HttpGet]
//        public IEnumerable<string> Get()
//        {
//            return new string[] { "value1", "value2" };
//        }

//        // GET api/<UserController>/5
//        [HttpGet("{id}")]
//        public string Get(int id)
//        {
//            return "value";
//        }

//        // POST api/<UserController>
//        [HttpPost]
//        public void Post([FromBody] string value)
//        {
//        }

//        // PUT api/<UserController>/5
//        [HttpPut("{id}")]
//        public void Put(int id, [FromBody] string value)
//        {
//        }

//        // DELETE api/<UserController>/5
//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//        }
//    }
//}
