using Lombok.NET;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace UserService.Models
{
    [AllArgsConstructor]
    [NoArgsConstructor]
    [With]
    [Table("role")]
    public partial class Role
    {
        [Key]
        [Column("id")]
        public string Id { get;  set; } = Guid.NewGuid().ToString();
        [Unicode]
        public string Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }
    }
}
