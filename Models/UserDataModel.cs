using System.ComponentModel.DataAnnotations;

namespace FreeTimeSpenderWeb.Models
{
    public class UserDataModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
