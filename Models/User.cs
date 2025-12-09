using System.ComponentModel.DataAnnotations;

namespace Login.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        // Use [Required] for validation
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)] // Hides input in the view
        public string Password { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;
    }
}
