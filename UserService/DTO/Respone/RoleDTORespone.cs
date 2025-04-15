using Lombok.NET;

namespace UserService.DTO.Respone
{
    [AllArgsConstructor]
    [NoArgsConstructor]
    public partial class RoleDTORespone
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
