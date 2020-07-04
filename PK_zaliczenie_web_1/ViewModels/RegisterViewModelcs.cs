using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PK_zaliczenie_web_1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PK_zaliczenie_web_1.ViewModels
{
    public class RegisterViewModelcs
    {
        [Required]
        public Roles Role { get; set; }

      

        [Required]
        [EmailAddress]
        [Remote(action: "IsEmailUsed" , controller:"Account")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name ="Confirm Password")]
        [Compare ("Password",ErrorMessage ="Passwords do not match")]
        public string ConfirmPassword { get; set; }


    }

}
