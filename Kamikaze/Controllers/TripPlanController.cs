﻿using System;
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
    public class TripPlanController : ControllerBase
    {
        private readonly ITripPlanRepository _tripPlanRepository;

        public TripPlanController(ITripPlanRepository tripPlanRepository)
        {
            _tripPlanRepository = tripPlanRepository;
        }

        // GET: api/<TripPlanController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tripPlanRepository.GetAllTripPlans());
        }

        //GET api/<TripPlanController>/5
        [HttpGet("{id}")]
        public IActionResult GetTripPlanById(int id)
        {
            var tripPlan = _tripPlanRepository.GetTripPlanById(id);
            if (tripPlan == null)
            {
                return NotFound();
            }
            return Ok(tripPlan);
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














//using Microsoft.AspNetCore.Mvc;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace Kamikaze.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class TripPlanController : ControllerBase
//    {
//        // GET: api/<TripPlanController>
//        [HttpGet]
//        public IEnumerable<string> Get()
//        {
//            return new string[] { "value1", "value2" };
//        }

//        // GET api/<TripPlanController>/5
//        [HttpGet("{id}")]
//        public string Get(int id)
//        {
//            return "value";
//        }

//        // POST api/<TripPlanController>
//        [HttpPost]
//        public void Post([FromBody] string value)
//        {
//        }

//        // PUT api/<TripPlanController>/5
//        [HttpPut("{id}")]
//        public void Put(int id, [FromBody] string value)
//        {
//        }

//        // DELETE api/<TripPlanController>/5
//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//        }
//    }
//}


