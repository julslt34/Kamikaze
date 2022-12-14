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
    public class DestinationController : ControllerBase
    {
        private readonly IDestinationRepository _destinationRepository;

        public DestinationController(IDestinationRepository destinationRepository)
        {
            _destinationRepository = destinationRepository;
        }

        // GET: api/<DestinationController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_destinationRepository.GetAllDestinations());
        }


        [HttpGet("GetDestinationByCategory")]
        public IActionResult GetDestinationByCategory(int CategoryId)
        {
            var destination = _destinationRepository.GetDestinationByCategory(CategoryId);

            return Ok(destination);
        }


        //GET api/<DestinationController>/5
        [HttpGet("{id}")]
        public IActionResult GetDestinationById(int id)
        {
            var destination = _destinationRepository.GetDestinationById(id);
            if (destination == null)
            {
                return NotFound();
            }
            return Ok(destination);
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

