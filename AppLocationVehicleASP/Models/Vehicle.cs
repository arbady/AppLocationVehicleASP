using AppLocationVehicleASP.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLocationVehicleASP.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string RegistrationNum { get; set; }
        public string Characteristic { get; set; }
        public NbPlace NbPlace { get; set; }
        public NbDoor NbDoor { get; set; }
        public Fuel Fuel { get; set; }
        public bool AirCo { get; set; }
        public bool Gps { get; set; }
        public Transmission? Transmission { get; set; }
        public int StateId { get; set; }
        public int ModelId { get; set; }
        public int CategoryId { get; set; }
    }
}
