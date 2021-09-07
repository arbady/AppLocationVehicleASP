using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLocationVehicleASP.Models.Forms
{
    public class ReservationForm
    {
        public int Id { get; set; }
        //[Required]
        //public DateTime ReservationDate { get; set; }
        [Required]
        public DateTime StartDateLocation { get; set; }
        [Required]
        public DateTime EndDateLocation { get; set; }
        [Required]
        public int ReturnAgency { get; set; }
        [Required]
        public bool DamageCover { get; set; }
        [Required]
        public bool RobberyCover { get; set; }
        [Required]
        public bool AgeRange { get; set; }
        //[Required]
        public int UserId { get; set; }
        [Required]
        public int AgencyId { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}
