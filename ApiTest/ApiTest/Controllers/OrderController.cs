using ApiTest.Entities;
using ApiTest.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetAllOrders() => Ok(_orderService.GetAllOrders());

        [HttpGet("{id}")]
        public ActionResult<Order?> GetOrderById(int id)
        {
            var order = _orderService.GetOrderById(id);
            return order != null ? Ok(order) : NotFound();
        }

        [HttpPost]
        public ActionResult AddOrder(Order order)
        {
            _orderService.AddOrder(order);
            return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, order);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateOrder(int id, Order order)
        {
            if (id != order.Id) return BadRequest();

            _orderService.UpdateOrder(order);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(int id)
        {
            _orderService.DeleteOrder(id);
            return NoContent();
        }
    }
}
