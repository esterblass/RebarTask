using Microsoft.AspNetCore.Mvc;
using RebarProject.Models;
using RebarProject.Services;
using System.Globalization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RebarProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrederController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrederController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        // GET: api/<OrederController>
        [HttpGet]
        public ActionResult<List<Order>> Get()
        {
            return orderService.Get();
        }

        // GET api/<OrederController>/5
        [HttpGet("{id}")]
        public ActionResult<Order> Get(string id)
        {
            var order = orderService.Get(id);
            if(order == null)
            {
                return NotFound($"Order with id = {id} not found");
            }
            return order;
        }

        // POST api/<OrederController>
        [HttpPost]
        public ActionResult<Order> Post([FromBody] Order order)
        {
            orderService.Create(order);
            return CreatedAtAction(nameof(Get), new { id = order.id }, order);
        }

        // PUT api/<OrederController>/5
        [HttpPut("{id}")]
        public ActionResult Put(String id, [FromBody] Order order)
        {
            var existingOrder = orderService.Get(id);
            if (existingOrder == null)
            {

            return NotFound($"Order with id =  {id} not fount");
            }
            orderService.Update(id, order);
            return NoContent();
        }

        // DELETE api/<OrederController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var order = orderService.Get(id);
            if( order == null)
            {
                return NotFound($"Order with id =  {id} not fount");
            }
            orderService.Remove(id);
            return Ok($"Order with id = {id} deleted");
        }
    }
}
