using Lombok.NET;

namespace UserService.DTO.Request
{
    [NoArgsConstructor]
    [AllArgsConstructor]
    public partial class CreateRoleDTO
    {
        public string Name { get; set; }
    }
}
