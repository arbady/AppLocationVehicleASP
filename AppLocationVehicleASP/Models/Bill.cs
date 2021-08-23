using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLocationVehicleASP.Models
{
    public class Bill
    {       
        public int Id { get; set; }
        public string BillNum { get; set; }
        public string Wording { get; set; }
        public DateTime BillDate { get; set; }
        public double AmountTotHTVA { get; set; }
        public double AmountTotTVA { get; set; }
        public bool Paid { get; set; }
        public int ContractId { get; set; }
        public int PaymentMethodId { get; set; }
    }
}
