using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PK_zaliczenie_web_1.ViewModels
{
    public class UnitEditViewModel : UnitAddViewModel
    {
        public int Id { get; set; }
        public string ExistingPhotoPath { get; set; }


    }
}
