using System.ComponentModel.DataAnnotations;

namespace NETMeetApp.ViewModels.Account
{
    public class RegisterVM
    {
        [Required, StringLength(100)]
        public string FullName { get; set; }
        [Required, StringLength(100)]
        public string UserName { get; set; }
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, DataType(DataType.Password), Compare(nameof(Password))]
        public string RepeatPassword { get; set; }
        [Required(ErrorMessage = "You must accept the terms and conditions to register.")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "You must accept the terms and conditions to register.")]
        public bool IsTermsAccepted { get; set; }

    }
}
