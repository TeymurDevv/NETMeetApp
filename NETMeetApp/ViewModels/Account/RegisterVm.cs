using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;

namespace NETMeetApp.ViewModels.Account
{
    public class RegisterVM
    {
        [Required,StringLength(100)]
        public string FullName { get; set; }
        [Required, StringLength(100)]
        public string UserName { get; set; }
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, DataType(DataType.Password), Compare(nameof(Password))]
        public string RepeatPassword { get; set; }
        [Required]
        public bool IsTermsAccepted { get; set; }

    }
}
