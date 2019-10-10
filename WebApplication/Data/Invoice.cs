using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Data {
    public class Invoice {
        public int Id { get; set; }
        public string InvoiceNr { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime? DueDate { get; set; }

        public IList<InvoiceLine> Lines { get; set; }

        public Invoice() {
            Lines = new List<InvoiceLine>();
        }
    }
}
