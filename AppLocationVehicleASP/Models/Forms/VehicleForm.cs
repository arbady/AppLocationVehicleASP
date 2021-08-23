using AppLocationVehicleASP.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLocationVehicleASP.Models.Forms
{
    public class VehicleForm
    {
        [Required] 
        public string RegistrationNum { get; set; }
        public string Characteristic { get; set; }
        [Required]
        public NbPlace NbPlace { get; set; }
        [Required]
        public NbDoor NbDoor { get; set; }
        [Required]
        public Fuel Fuel { get; set; }
        [Required]
        public bool AirCo { get; set; }
        [Required]
        public bool Gps { get; set; }
        public Transmission? Transmission { get; set; }
        [Required]
        public int StateId { get; set; }
        [Required]
        public int ModelId { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}
