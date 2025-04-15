using Lombok.NET;

namespace MenuServices.DTO.Request
{
    [AllArgsConstructor]
    [NoArgsConstructor]
    public partial class AddCategoryReqDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
