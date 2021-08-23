using AppLocationVehicleASP.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLocationVehicleASP.Models
{
    public class State
    {
        public int Id { get; set; }
        public StateType StateType { get; set; }
        public string Description { get; set; }
}
}
