using System.ComponentModel.DataAnnotations;

namespace FutureRealty.PL.ViewModels
{
    public class ResetPasswordVM
    {
        [Required(ErrorMessage = "password is required ..")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "confirm password is required ..")]
        [DataType(DataType.Password)]
        [Compare(nameof(NewPassword))]
        public string ConfirmPassword { get; set; }

        public string Email { get; set; }
        public string Token { get; set; }


    }
}
