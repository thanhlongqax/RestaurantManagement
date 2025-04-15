using Lombok.NET;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserService.DTO;
using UserService.DTO.Request;
using UserService.Models;
using UserService.Repository;
using UserService.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserService.Controllers
{
    [Route("api/role")]
    [ApiController]
    [RequiredArgsConstructor]
    public partial class RoleController : ControllerBase
    {
        private readonly IRoleRepository roleRepository;
        // ✅ Lấy danh sách Role với phân trang và tìm kiếm
        [HttpGet]
        [Authorize(Roles = "Admin, Manager , Employee")]
        public async Task<ActionResult<ResDTO<IEnumerable<Role>>>> GetRoles(
            [FromQuery] int page = 1,
            [FromQuery] int limit = 10,
            [FromQuery] string? keyword = null)
        {
            var result = await roleRepository.GetRoles(page, limit, keyword);
            return StatusCode(result.Code, result);
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, Manager , Employee")]
        public async Task<ActionResult<ResDTO<Role>>> GetRoleById(string id)
        {
            var result = await roleRepository.GetRoleById(id);
            return StatusCode(result.Code, result);
        }

        // POST api/<RoleController>
        [HttpPost]
        
        [Authorize(Roles = "Admin, Manager ")]
        public async Task<ActionResult<ResDTO<Role>>> CreateRole([FromBody] CreateRoleDTO roleDto)
        {
            var result = await roleRepository.CreateRole(roleDto.Name);
            return StatusCode(result.Code, result);
        }

        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin, Manager ")]
        public async Task<ActionResult<ResDTO<Role>>> UpdateRole(string id, [FromBody] UpdateRoleDTO roleDto)
        {
            var result = await roleRepository.UpdateRole(id, roleDto.Name);
            return StatusCode(result.Code, result);
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin, Manager ")]
        public async Task<ActionResult<ResDTO<Role>>> DeleteRole(string id)
        {
            var result = await roleRepository.DeleteRole(id);
            return StatusCode(result.Code, result);
        }
    }
}
