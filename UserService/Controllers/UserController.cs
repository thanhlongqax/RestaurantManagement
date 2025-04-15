using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserService.DTO.Request;
using UserService.DTO;
using UserService.Models;
using UserService.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserService.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userService;
        public UserController(IUserRepository userService)
        {
            _userService = userService;
        }
        // 📌 Lấy danh sách user (có tìm kiếm & phân trang)
        [HttpGet]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<ActionResult<ResDTO<IEnumerable<User>>>> GetUsers(int page = 1, int limit = 10, string? keyword = null)
        {
            var result = await _userService.GetUsers(page, limit, keyword);
            return StatusCode(result.Code, result);
        }

        // 📌 Lấy thông tin chi tiết user theo ID
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<ActionResult<ResDTO<User>>> GetUser(string id)
        {
            var result = await _userService.GetUser(id);
            return StatusCode(result.Code, result);
        }

        // 📌 Thêm user mới
        [HttpPost]
        [Authorize(Roles = "Admin ,Manager")]
        public async Task<ActionResult<ResDTO<string>>> AddUser([FromBody] CreateUserDTO userDto)
        {
            var result = await _userService.AddUser(userDto);
            return StatusCode(result.Code, result);
        }

        // 📌 Cập nhật thông tin user
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<ActionResult<ResDTO<string>>> UpdateUser(string id, [FromBody] UserDTO userDto)
        {
            userDto.Id = id;
            var result = await _userService.UpdateUser(userDto);
            return StatusCode(result.Code, result);
        }

        // 📌 Xóa user
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin ,Manager")]
        public async Task<ActionResult<ResDTO<string>>> DeleteUser(string id)
        {
            var result = await _userService.DeleteUser(id);
            return StatusCode(result.Code, result);
        }

        // 📌 Đăng nhập bằng Email & Password
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<ResDTO<string>>> Login([FromBody] LoginDTO loginDto)
        {
            var result = await _userService.Login(loginDto.email, loginDto.password);
            return StatusCode(result.Code, result);
        }

        // 📌 Đăng nhập bằng mã PIN
        [HttpPost("login-pin")]
        [AllowAnonymous]
        public async Task<ActionResult<ResDTO<string>>> LoginByPinCode([FromBody] PinLoginDTO pinDto)
        {
            var result = await _userService.LoginByPinCode(pinDto.pinCode);
            return StatusCode(result.Code, result);
        }
    }
}
