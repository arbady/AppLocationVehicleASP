using AppLocationVehicleASP.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLocationVehicleASP.Models
{
    public class Category
    {
        public int Id { get; set; }
        public TypeCat TypeCat { get; set; }
        public double CostPerDay { get; set; }
    }
}
