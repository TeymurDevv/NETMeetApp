﻿using Microsoft.AspNetCore.Identity;

namespace NETMeetApp.Models
{
    public class TeacherAppUser : IdentityUser
    {
        public string CvUrl { get; set; }
        public string FullName { get; set; }
        public string imageUrl { get; set; }
        public string Country { get; set; }
        public string BioGraphy { get; set; }
        public int Age { get; set; }
        public enum Gender { Male, Female }
    }
}