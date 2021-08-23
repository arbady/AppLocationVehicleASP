using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLocationVehicleASP.Models.Forms
{
    public class BillForm
    {       
        [Required]
        public string BillNum { get; set; }
        [Required]
        public string Wording { get; set; }
        [Required]
        public DateTime BillDate { get; set; }
        [Required]
        public double AmountTotHTVA { get; set; }
        [Required]
        public double AmountTotTVA { get; set; }
        [Required]
        public bool Paid { get; set; }
        [Required]
        public int ContractId { get; set; }
        [Required]
        public int PaymentMethodId { get; set; }
    }
}
