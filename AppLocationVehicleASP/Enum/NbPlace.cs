using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLocationVehicleASP.Enum
{
    public enum NbPlace
    {
        [Display(Name = "2")]
        Deux, 

        [Display(Name = "3")]
        Trois,

        [Display(Name = "4")]
        Quatre,

        [Display(Name = "5")]
        Cinq,

        [Display(Name = "6")]
        Six,

        [Display(Name = "7")]
        Sept,

        [Display(Name = "8")]
        Huit,

        [Display(Name = "9 ou plus")]
        NeufEtPlus = 9
    }

}
