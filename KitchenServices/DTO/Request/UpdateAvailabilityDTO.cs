using Lombok.NET;

namespace KitchenServices.DTO.Request
{
    [AllArgsConstructor]
    [NoArgsConstructor]
    public partial class UpdateAvailabilityDTO
    {
        public bool IsAvailable { get; set; }
    }
}
