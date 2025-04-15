using KitchenServices.Models;
using KitchenServices.Service;
using Lombok.NET;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KitchenServices.Controllers
{
    [Route("api/kitchen")]
    [ApiController]
    [RequiredArgsConstructor]
    public partial class KitchenController : ControllerBase
    {
        private readonly IKitchenService _kitchenService;
        // GET: api/<KitchenController>
        [HttpGet("pending")]
        public async Task<IActionResult> GetPendingOrders()
        {
            var result = await _kitchenService.GetPendingOrders();
            return StatusCode(result.Code, result);
        }

        // POST api/<KitchenController>
        [HttpPost("create")]
        public async Task<IActionResult> CreateKitchenOrder([FromBody] KitchenOrder order)
        {
            var result = await _kitchenService.CreateKitchenOrder(order);
            return StatusCode(result.Code, result);
        }

        // PUT api/<KitchenController>/5
        [HttpPut("order/{orderId}/complete")]
        public async Task<IActionResult> MarkOrderCompleted(string orderId)
        {
            var result = await _kitchenService.MarkOrderCompleted(orderId);
            return StatusCode(result.Code, result);
        }

        // DELETE api/<KitchenController>/5
        [HttpPut("item/{itemId}/complete")]
        public async Task<IActionResult> MarkItemCompleted(string itemId)
        {
            var result = await _kitchenService.MarkItemCompleted(itemId);
            return StatusCode(result.Code, result);
        }
    }
}
