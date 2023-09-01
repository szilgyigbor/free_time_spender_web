using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreeTimeSpenderWeb.Models
{
    public class UserData
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string? Username { get; set; }

        [Column(TypeName = "text")]
        public string? Email { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string? Password { get; set; }

        public bool IsAdmin { get; set; } = false;

        public bool IsFriend { get; set; } = false;

        public DateTime RegistratedAt { get; set; }
    }
}
