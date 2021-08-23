using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLocationVehicleASP.Models.Forms
{
    public class MarkForm
    {
        [Required]
        public string Name { get; set; }
    }
}
