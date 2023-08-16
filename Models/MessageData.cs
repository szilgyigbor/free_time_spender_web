using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FreeTimeSpenderWeb.Models
{
    public class MessageData
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "text")]
        [StringLength(500)]
        public string? Message { get; set; }

        [Required]
        [Column(TypeName = "text")]
        [StringLength(50)]
        public string? Username { get; set; }

        public DateTime PostedAt { get; set; }
    }
}
