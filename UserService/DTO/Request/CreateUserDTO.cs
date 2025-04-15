using System.ComponentModel.DataAnnotations;

namespace UserService.DTO.Request
{
    public class CreateUserDTO
    {
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
     
        [MaxLength(6, ErrorMessage = "Pin code chỉ có  6 ký tự")]
        public string? PinCode { get; set; }
        [Required(ErrorMessage = "Ngày sinh không được để trống")]
        public DateTime DateOfBirth { get; set; }

        public List<string> RoleIds { get; set; } = new List<string>();
    }
}
