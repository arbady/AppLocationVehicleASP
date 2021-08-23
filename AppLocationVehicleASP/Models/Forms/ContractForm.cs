using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLocationVehicleASP.Models.Forms
{
    public class ContractForm
    {
        [Required]
        public int ContractNum { get; set; }
        [Required]
        public DateTime RealReturnDate { get; set; }
        [Required]
        public string DepartKm { get; set; }
        [Required]
        public string BackKm { get; set; }
        [Required]
        public DateTime ContractDate { get; set; }
        [Required]
        public double AmountTotHTVA { get; set; }
        [Required]
        public double AmountTotTVA { get; set; }
        [Required]
        public bool Signed { get; set; }
        [Required]
        public int ReservationId { get; set; }
        [Required]
        public int VehicleId { get; set; }
        [Required]
        public int PenalizationId { get; set; }
    }
}
