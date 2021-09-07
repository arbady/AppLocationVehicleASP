using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLocationVehicleASP.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime StartDateLocation { get; set; }
        public DateTime EndDateLocation { get; set; }
        public int ReturnAgency { get; set; }
        public bool DamageCover { get; set; }
        public bool RobberyCover { get; set; }
        public bool AgeRange { get; set; }
        public bool IsCancelled { get; set; }
        public int UserId { get; set; }
        public int AgencyId { get; set; }
        public int CategoryId { get; set; }
        public User User { get; set; }
        public Agency Agency { get; set; }
        public Category Category { get; set; }
    }
}
