using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PK_zaliczenie_web_1.Models
{
    public class Units
    {
        public int Id { get; set; }

       
        public string Name { get; set; }

        
        public int Attack { get; set; }

    
        public int Defense { get; set; }

       
        public int min_Damage { get; set; }

       
        public int max_Damage { get; set; }

 
        public int Health { get; set; }


         
        public Factions Faction { get; set; }

        public string PhotoPath { get; set; }
    }
}
