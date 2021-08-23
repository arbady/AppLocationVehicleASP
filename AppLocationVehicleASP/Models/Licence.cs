using AppLocationVehicleASP.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLocationVehicleASP.Models
{
    public class Licence
    {
        public int Id { get; set; }
        public LicenceCat LicenceCat { get; set; }
        public string Description { get; set; }
    }
}
