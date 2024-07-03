using System.ComponentModel.DataAnnotations;

namespace NETMeetApp.ViewModels.HomeWork
{
    public class HomeWorkUpdateVM
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string GroupName { get; set; }

    }
}
