using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using mtm.Models;
using mtm.Services;

namespace mtm.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractorsController : ControllerBase
    {
        private readonly ContractorsService _cservice;
        public ContractorsController(ContractorsService cservice)
        {
            _cservice = cservice;
        }

        [HttpGet]
        public ActionResult<Contractor> Get()
        {
            try
            {
                return Ok(_cservice.GetAll());
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{id}")]  // NOTE '{}' signifies a var parameter
        public ActionResult<Contractor> Get(int id)
        {
            try
            {
                return Ok(_cservice.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        // NOTE ANYTIME you need to use Async/Await you will return a Task
        public ActionResult<Contractor> Create([FromBody] Contractor newContractor)
        {
            try
            {
                // NOTE HttpContext == 'req'
                return Ok(_cservice.Create(newContractor));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Contractor> Edit([FromBody] Contractor updated, int id)
        {
            try
            {
                updated.Id = id;
                return Ok(_cservice.Edit(updated));
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Contractor> Delete(int id)
        {
            try
            {
                return Ok(_cservice.Delete(id));
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}