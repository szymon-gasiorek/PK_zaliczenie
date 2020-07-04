using Microsoft.AspNetCore.Http;
using PK_zaliczenie_web_1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PK_zaliczenie_web_1.ViewModels
{
    public class UnitAddViewModel
    {
        [Required]
        [MaxLength(30, ErrorMessage = "Name cannot be longer then 30 characters")]
        public string Name { get; set; }

        [Required]
        [Range(1, 1000, ErrorMessage = "Attack needs to be between 1-1000")]
        public int Attack { get; set; }

        [Required]
        [Range(1, 1000, ErrorMessage = "Defense needs to be between 1-1000")]
        public int Defense { get; set; }

        [Required]
        [Range(1, 1000, ErrorMessage = "Minimum damage needs to be between 1-1000")]
        public int min_Damage { get; set; }

        [Required]
        [Range(1, 1000, ErrorMessage = "Maximum damage needs to be between 1-1000")]
        public int max_Damage { get; set; }

        [Required]
        [Range(1, 1000, ErrorMessage = "Health needs to be between 1-1000")]
        public int Health { get; set; }

        [Required]
        public Factions Faction { get; set; }

        public IFormFile Photo { get; set; }
    }
}
