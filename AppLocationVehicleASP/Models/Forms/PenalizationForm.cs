using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLocationVehicleASP.Models.Forms
{
    public class PenalizationForm
    {
        public string Description { get; set; }
        [Required]
        public DateTime PenalDate { get; set; }
        [Required]
        public double AmountOwed { get; set; }
        [Required]
        public double AmountPaid { get; set; }
    }
}
