﻿using System.ComponentModel.DataAnnotations;

namespace NETMeetApp.ViewModels.Account
{
    public class ResetPasswordVM
    {
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
