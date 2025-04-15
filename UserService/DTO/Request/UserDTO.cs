using Lombok.NET;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace UserService.DTO.Request
{
    [AllArgsConstructor]
    [NoArgsConstructor]
    public partial class UserDTO
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required(ErrorMessage = "Tên không được để trống")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Họ không được để trống")]
        public string LastName { get; set; }
        public string Username { get; set; }
        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [MinLength(6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự")]
        public string Password { get; set; }
        public string PinCode { get;  set; }
        [Required(ErrorMessage = "Ngày sinh không được để trống")]
        public DateTime DateOfBirth { get; set; }

        public List<string> RoleIds { get; set; } = new List<string>();
    }
}
