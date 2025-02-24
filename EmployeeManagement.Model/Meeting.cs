using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical123.Models
{
    [Table("Meeting")]
    public class Meeting:BaseEntity
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Ajenda { get; set; }
        [Required]
        [DateGreaterThanNow("Please choose future date")]
        public DateTime Date { get; set; }
    }
}
