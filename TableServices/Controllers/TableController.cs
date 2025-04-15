using Lombok.NET;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TableServices.DTO;
using TableServices.DTO.Request;
using TableServices.Enums;
using TableServices.Models;
using TableServices.Repository;
using TableServices.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TableServices.Controllers
{
    [Route("api/tables")]
    [ApiController]
    [RequiredArgsConstructor]
    public partial class TableController : ControllerBase
    {
        private readonly ITableRepository tableRepository;
        
        [HttpGet]
        //[Authorize(Roles = "Admin, Manager , Employee")]
        [AllowAnonymous]
        public async Task<ActionResult<ResDTO<IEnumerable<Table>>>> GetTables() => Ok(await tableRepository.GetTables());

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, Manager , Employee")]
        public async Task<ActionResult<ResDTO<Table>>> GetTableById(string id) => Ok(await tableRepository.GetTableById(id));
        
        [HttpGet("{tableId}/status")]
        [Authorize(Roles = "Admin, Manager , Employee")]
        public async Task<IActionResult> GetTableStatus(string tableId)
        {
            var result = await tableRepository.IsTableStatusExistsAsync(tableId);
            return StatusCode(result.Code, result);
        }
        // POST api/<TableController>
        [HttpPost]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<ActionResult<ResDTO<Table>>> AddTable([FromBody] AddTableRequestDTO table)
        {
           var result =  await tableRepository.AddTable(table);
            return StatusCode(result.Code, result);
        }
          

        // PUT api/<TableController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> UpdateTable(string id, [FromBody] Table table)
        {
            table.Id = id;
            return Ok(await tableRepository.UpdateTable(table));
        }

        [HttpPut("{tableId}/status")]
        [Authorize(Roles = "Admin, Manager , Employee")]
        public async Task<IActionResult> UpdateTableStatus(string tableId, [FromBody] TableStatus newStatus)
        {
            var result = await tableRepository.UpdateTableStatusAsync(tableId, newStatus);
            return StatusCode(result.Code, result);
        }


        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> DeleteTable(string id) => Ok(await tableRepository.DeleteTable(id));
    }
}
