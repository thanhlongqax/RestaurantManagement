using Lombok.NET;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TableServices.Enums;

namespace TableServices.DTO.Request
{
    [NoArgsConstructor]
    [AllArgsConstructor]
    public partial class AddTableRequestDTO
    {
        [Required(ErrorMessage = "Số bàn không được để trống")]
        public int Number { get; set; }
        [Required(ErrorMessage = "Tổng khác phục vụ không được để trống")]
        public int Capacity { get; set; }
        [Required(ErrorMessage = "Trạng thái bàn không được để trống")]

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TableStatus Status { get; set; } = TableStatus.Available;
    }
}
