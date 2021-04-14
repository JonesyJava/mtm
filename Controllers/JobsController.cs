using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using mtm.Models;
using mtm.Services;

namespace mtm.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly JobsService _jservice;
        public JobsController(JobsService jservice)
        {
            _jservice = jservice;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Job>> Get()
        {
            try
            {
                return Ok(_jservice.GetAll());
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{id}")]  // NOTE '{}' signifies a var parameter
        public ActionResult<Job> Get(int id)
        {
            try
            {
                return Ok(_jservice.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        // NOTE ANYTIME you need to use Async/Await you will return a Task
        public ActionResult<Job> Create([FromBody] Job newJob)
        {
            try
            {
                // NOTE HttpContext == 'req'
                return Ok(_jservice.Create(newJob));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Job> Edit([FromBody] Job updated, int id)
        {
            try
            {
                updated.Id = id;
                return Ok(_jservice.Edit(updated));
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Job> Delete(int id)
        {
            try
            {
                return Ok(_jservice.Delete(id));
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}