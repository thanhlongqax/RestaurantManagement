using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Lombok.NET;

namespace MenuServices.Models
{
    [AllArgsConstructor]
    [NoArgsConstructor]
    public partial class Category
    {
        [Key]
        [Column("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
