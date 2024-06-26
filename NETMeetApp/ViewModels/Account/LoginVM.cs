using System.ComponentModel.DataAnnotations;

namespace NETMeetApp.ViewModels.Account
{
    public class LoginVM
    {
        [Required]
        public string UserNameOrEmail { get; set; }
        [Required,DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
