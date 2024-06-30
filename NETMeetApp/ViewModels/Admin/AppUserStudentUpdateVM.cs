﻿using System.ComponentModel.DataAnnotations;

namespace NETMeetApp.ViewModels.Admin
{
    public class AppUserStudentUpdateVM
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, DataType(DataType.Password), Compare(nameof(Password))]
        public string RepeatPassword { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string GroupName { get; set; }
        [Required]
        public IFormFile ProfileImage { get; set; }
    }
}
