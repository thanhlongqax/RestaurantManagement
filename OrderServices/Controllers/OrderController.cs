using Lombok.NET;
using Microsoft.AspNetCore.Mvc;
using OrderServices.DTO;
using OrderServices.DTO.Request;
using OrderServices.Models;
using OrderServices.Service;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderServices.Controllers
{
    [Route("api/orders")]
    [ApiController]
    [RequiredArgsConstructor]
    public partial class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        // GET: api/<OrderController>
        [HttpGet]
        public async Task<IActionResult> GetAllOrders([FromQuery] int page = 1, [FromQuery] int limit = 10, [FromQuery] string? search = null)
        {
            var response = await _orderService.GetAllOrdersAsync(page, limit, search);
            return StatusCode(response.Code, response);
        }


        // GET api/<OrderController>/5
        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrderById(string orderId)
        {
            var result = await _orderService.GetOrderByIdAsync(orderId);
            return StatusCode(result.Code, result);
        }


        // POST api/<OrderController>
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDTO orderDto)
        {
            var token = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            if (orderDto == null)
                return BadRequest(new ResDTO<Order> { Code = 400, Message = "Dữ liệu không hợp lệ" });

            var result = await _orderService.CreateOrder(orderDto , token);
            return StatusCode(result.Code, result);
            //return StatusCode((int)HttpStatusCode.OK, token);
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
