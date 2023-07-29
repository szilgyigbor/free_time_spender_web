using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreeTimeSpenderWeb.Models
{
    public class UserDataModel
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
    }
}
