using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Lombok.NET;
using TableServices.Enums;
using System.Text.Json.Serialization;

namespace TableServices.Models
{
    [AllArgsConstructor]
    [NoArgsConstructor]
    [Table("table")]
    public partial class Table
    {
        [Key]
        [Column("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int Number { get; set; }
        public int Capacity { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TableStatus Status { get; set; } = TableStatus.Available;
    }
}
