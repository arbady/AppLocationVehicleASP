using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLocationVehicleASP.Models
{
    public class Contract
    {
        public int Id { get; set; }
        public int ContractNum { get; set; }
        public DateTime RealReturnDate { get; set; }
        public string DepartKm { get; set; }
        public string BackKm { get; set; }
        public DateTime ContractDate { get; set; }
        public double AmountTotHTVA { get; set; }
        public double AmountTotTVA { get; set; }
        public bool Signed { get; set; }
        public int ReservationId { get; set; }
        public int VehicleId { get; set; }
        public int PenalizationId { get; set; }
    }
}
