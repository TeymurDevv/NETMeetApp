using System.ComponentModel.DataAnnotations;

namespace NETMeetApp.ViewModels.Admin
{
    public class AppUserStudentUpdateVM
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string GroupName { get; set; }
        public IFormFile? ProfileImage { get; set; }
    }
}
