using System.ComponentModel.DataAnnotations;

namespace FutureRealty.PL.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "username is required ..")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "email is required ..")]
        [MinLength(5)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "password is required ..")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "confirm password is required ..")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

    }
}
