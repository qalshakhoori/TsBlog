using System.ComponentModel.DataAnnotations;

namespace TsBlog.ViewModel.User
{
    /// <summary>
    /// User Register View Entities
    /// </summary>
    public class RegisterViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password), MaxLength(20), MinLength(6)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password), Compare("Password", ErrorMessage = "Two Password Inconsistencies")]
        public string ConfirmPassword { get; set; }
    }
}