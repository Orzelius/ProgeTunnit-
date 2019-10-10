using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Data {
    public class InvoiceLine {
        public int Id { get; set; }
        public string LineItemName { get; set; }
        public double Sum { get; set; }
        public int Amount { get; set; }
    }
}
