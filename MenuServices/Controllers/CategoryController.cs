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
    [Route("api/category")]
    [ApiController]
    [RequiredArgsConstructor]
    public partial class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        // GET: api/<CategoryController>
        [HttpGet]
        [Authorize(Roles = "Admin, Manager, Employee")]
        public async Task<ActionResult<ResDTO<object>>> GetCategories([FromQuery] int page = 1, [FromQuery] int limit = 10, [FromQuery] string? keyword = null)
        {
            var result = await categoryService.GetCategories(page, limit, keyword);
            return StatusCode(result.Code, result);
        }


        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, Manager , Employee")]
        public async Task<ActionResult<ResDTO<Category>>> GetCategoryById(string id)
        {
            var result = await categoryService.GetCategoryById(id);
            return StatusCode(result.Code, result);
        }

        // POST api/<CategoryController>
        [HttpPost]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<ActionResult<ResDTO<Category>>> AddCategory([FromBody] AddCategoryReqDTO categoryDto)
        {
            var result = await categoryService.AddCategory(categoryDto);
            return StatusCode(result.Code, result);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin, Manager ")]
        public async Task<ActionResult<ResDTO<Category>>> UpdateCategory(string id, [FromBody] UpdateCategoryReqDTO updateCategoryReqDTO)
        {
            updateCategoryReqDTO.Id = id;
            var result = await categoryService.UpdateCategory(updateCategoryReqDTO);
            return StatusCode(result.Code, result);
        }
        [Authorize(Roles = "Admin, Manager ")]
        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResDTO<Category>>> DeleteCategory(string id)
        {
            var result = await categoryService.DeleteCategory(id);
            return StatusCode(result.Code, result);
        }
    }
}
