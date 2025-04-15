using Lombok.NET;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MenuServices.Models
{
    [AllArgsConstructor]
    [NoArgsConstructor]
    public partial class MenuItem
    {
        [Key]
        [Column("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public string Image { get; set; }
        public bool IsAvailable { get; set; } = true;

        public Category Category { get; set; }
    }
}
