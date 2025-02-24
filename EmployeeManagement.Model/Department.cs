using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practical123.Models
{
    [Table("Department")]
    public class Department : BaseEntity
    {
        [Required]
        [Key]
        public Guid Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
    }
}
