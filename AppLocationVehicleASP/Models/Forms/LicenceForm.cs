using AppLocationVehicleASP.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLocationVehicleASP.Models.Forms
{
    public class LicenceForm
    {
        [Required]
        public LicenceCat LicenceCat { get; set; }
        public string Description { get; set; }
    }
}
