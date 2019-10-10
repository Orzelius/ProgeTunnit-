using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Data {
    public class MyDbContext : DbContext{
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceLine> InvoiceLines { get; set; }
    }
}
