using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLocationVehicleASP.Models.Forms
{
    public class AgencyForm
    {
        //public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Airport { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int ZipCode { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public bool IsClosed { get; set; }
    }
}
