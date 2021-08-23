using AppLocationVehicleASP.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLocationVehicleASP.Models
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        public Method Method { get; set; }
    }
}
