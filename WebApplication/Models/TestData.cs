using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Data;

namespace WebApplication.Models {

    public class TestData {
        public static IList<Invoice> Invoices {
            get {
                return new List<Invoice>() {

                    new Invoice
                    {
                        Id = 1,
                        InvoiceNr = "2019/01",
                        InvoiceDate = DateTime.Now,
                        DueDate = DateTime.Now.AddDays(14).Date,

                        Lines = new List<InvoiceLine>
                        {
                            new InvoiceLine{ Id = 1, LineItemName = "Coca-Cola", Amount = 1, Sum = 1},
                            new InvoiceLine{ Id = 2, LineItemName = "Eesti Juust", Amount = 3, Sum = 7},
                            new InvoiceLine{ Id = 3, LineItemName = "Tomatipasta", Amount = 1, Sum = 2},
                            new InvoiceLine{ Id = 4, LineItemName = "Ananass", Amount = 5, Sum = 10}
                        }

                    },

                    new Invoice
                    {
                        Id = 2,
                        InvoiceNr = "2019/02",
                        InvoiceDate = DateTime.Now,
                        DueDate = DateTime.Now.AddDays(14).Date,

                        Lines = new List<InvoiceLine>
                        {
                            new InvoiceLine{ Id = 5, LineItemName = "Sai", Amount = 1, Sum = 0.5f},
                            new InvoiceLine{ Id = 6, LineItemName = "Lastevorst", Amount = 3, Sum = 3},
                            new InvoiceLine{ Id = 7, LineItemName = "Põdraliha", Amount = 2, Sum = 50},
                            new InvoiceLine{ Id = 8, LineItemName = "Margariin", Amount = 1, Sum = 2}
                        }

                    }

                };
            }
        }
    }
}
