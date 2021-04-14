using Microsoft.AspNetCore.Mvc;
using mtm.Models;
using Services;

namespace mtm.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BidsController : ControllerBase
    {
        private readonly BidsService _bservice;
        public BidsController(BidsService bservice)
        {
            _bservice = bservice;
        }

        [HttpPost]
        public ActionResult<Bid> Create([FromBody] Bid newBid)
        {
            try
            {
                return Ok(_bservice.Create(newBid));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            try
            {
                _bservice.Delete(id);
                return Ok("DELETED");
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}