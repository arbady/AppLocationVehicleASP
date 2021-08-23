using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLocationVehicleASP.Models.Forms
{
    public class DisponibilitiesModel
    {
        [Required]
        public DateTime AvailDateDepart { get; set; }
        [Required]
        public DateTime AvailDateReturn { get; set; }
        [Required]
        public int AgencyId { get; set; }
        [Required]
        public int VehicleId { get; set; }
    }
}
