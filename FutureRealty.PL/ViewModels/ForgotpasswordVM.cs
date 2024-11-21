using System.ComponentModel.DataAnnotations;

namespace FutureRealty.PL.ViewModels
{
    public class ForgotpasswordVM
    {
        [Required(ErrorMessage = "email is required ..")]
        [MinLength(5)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
