using Lombok.NET;
using MenuServices.DTO;
using MenuServices.DTO.Request;
using MenuServices.Models;
using MenuServices.Repository;
using MenuServices.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MenuServices.Controllers
{
    [Route("api/menu")]
    [ApiController]
    [RequiredArgsConstructor]
    public partial class MenuController : ControllerBase
    {
        private readonly IMenuService menuService;
        // GET: api/<MenuController>
        [HttpGet]
        [Authorize(Roles = "Admin, Manager, Employee")]
        public async Task<ActionResult<ResDTO<object>>> GetMenuItems([FromQuery] int page = 1, [FromQuery] int limit = 10, [FromQuery] string? keyword = null)
        {
            var result = await menuService.GetMenuItems(page, limit, keyword);
            return StatusCode(result.Code, result);
        }


        // GET api/<MenuController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, Manager , Employee")]
        public async Task<ActionResult<ResDTO<MenuItem>>> GetMenuItemById(string id)
        {
            var result = await menuService.GetMenuItemById(id);
            return StatusCode(result.Code, result);
        }
        [HttpPost("get-menu-items")]
        public async Task<ActionResult<ResDTO<List<MenuItem>>>> GetMenuItemsByIds([FromBody] List<string> ids)
        {
            if (ids == null || ids.Count == 0)
            {
                // Trả về lỗi 400 với thông báo chi tiết
                return StatusCode(StatusCodes.Status400BadRequest, new ResDTO<object>
                {
                    Code = 400,
                    Message = "Danh sách IDs không hợp lệ hoặc chưa được truyền vào.",
                    Data = null
                });
            }

            var result = await menuService.GetMenuItemsByIds(ids);
            return StatusCode(result.Code, result);
        }
        // POST api/<MenuController>
        [HttpPost]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<ActionResult<ResDTO<MenuItem>>> AddMenuItem([FromBody] AddMenuItemReqtDTO menuItemDto)
        {
            var result = await menuService.AddMenuItem(menuItemDto);
            return StatusCode(result.Code, result);
        }

        // PUT api/<MenuController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<ActionResult<ResDTO<MenuItem>>> UpdateMenuItem(string id, [FromBody] UpdateMenuItemReqtDTO updateDto)
        {
            updateDto.Id = id;
            var result = await menuService.UpdateMenuItem(updateDto);
            return StatusCode(result.Code, result);
        }

        [HttpPatch("{id}/availability")]
        //[Authorize(Roles = "Admin, Manager , Employee")]
        public async Task<IActionResult> UpdateAvailability(string id, [FromBody] bool isAvailable)
        {
            var result = await menuService.UpdateMenuItemAvailability(id, isAvailable);
            return StatusCode(result.Code, result);
        }

        // DELETE api/<MenuController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<ActionResult<ResDTO<MenuItem>>> DeleteMenuItem(string id)
        {
            var result = await menuService.DeleteMenuItem(id);
            return StatusCode(result.Code, result);
        }
    }
}
