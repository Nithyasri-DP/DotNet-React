﻿using System.ComponentModel.DataAnnotations;

namespace Authentication_Demo.Authentication
{
    public class LoginModel
    {
        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
