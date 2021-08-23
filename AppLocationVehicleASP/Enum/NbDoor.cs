using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLocationVehicleASP.Enum
{
    public enum NbDoor
    {
        [Display(Name = "2")]
        Deux,

        [Display(Name = "3")]
        Trois,

        [Display(Name = "4")]
        Quatre,

        [Display(Name = "5")]
        Cinq
    }
}
