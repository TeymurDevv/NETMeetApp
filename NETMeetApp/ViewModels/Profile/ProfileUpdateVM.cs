using System.ComponentModel.DataAnnotations;

namespace NETMeetApp.ViewModels.Profile
{
    public class ProfileUpdateVM
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string? Country { get; set; }
        [Required]
        public int? Grade { get; set; }
        [Required]
        public IFormFile? ProfileImage { get; set; }
        [Required]
        public int? Age { get; set; }
        [Required]
        public string? Biography { get; set; }
    }
}
