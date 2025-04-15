using Lombok.NET;

namespace MenuServices.DTO.Request
{
    [NoArgsConstructor]
    [AllArgsConstructor]
    public partial class UpdateCategoryReqDTO
    {
        public string Id { get; set; } 
        public string? Name { get; set; }

        public string? Description { get; set; }
    }
}
