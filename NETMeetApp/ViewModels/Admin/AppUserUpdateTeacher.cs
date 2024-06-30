using System.ComponentModel.DataAnnotations;

namespace NETMeetApp.ViewModels.Admin
{
    public class AppUserUpdateTeacher
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string UserName { get; set; }
       
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
         public IFormFile? ProfileImage {  get; set; }
    }
}
