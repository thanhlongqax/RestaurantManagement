using Lombok.NET;

namespace UserService.DTO.Request
{
    [AllArgsConstructor]
    [NoArgsConstructor]
    public partial class UpdateRoleDTO
    {
        public string Name { get; set; }
    }
}
