﻿using Microsoft.AspNetCore.Identity;

namespace NETMeetApp.Models
{
    public class StudentAppUser : IdentityUser
    {
        public int Grade { get; set; }
        public string FullName { get; set; }
        public string imageUrl { get; set; }
        public string Country { get; set; }
        public string BioGraphy { get; set; }
        public int Age { get; set; }
        public enum Gender { Male, Female }
        public bool IsPassed => Grade >= 60 ? true : false;
        public Group Group { get; set; }
        public int GroupId { get; set; }

    }
}
