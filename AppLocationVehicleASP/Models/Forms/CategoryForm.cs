using AppLocationVehicleASP.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLocationVehicleASP.Models.Forms
{
    public class CategoryForm
    {
        [Required]
        public TypeCat TypeCat { get; set; }
        [Required]
        public double CostPerDay { get; set; }
    }
}
