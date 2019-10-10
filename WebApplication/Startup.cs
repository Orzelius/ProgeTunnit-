using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplication.Services;
using WebApplication.Data;

namespace WebApplication {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.Configure<CookiePolicyOptions>(options => {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddDbContext<MyDbContext>(options => {
                //This is an in-memory db
                //options.UseInMemoryDatabase(Guid.Empty.ToString());
                options.UseSqlite("Data Source=mydb.db");
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<IMessageService, Mailer>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            else {
                app.UseExceptionHandler("/Home/Error");
            }

            var serviceScopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            using (var serviceScope = serviceScopeFactory.CreateScope()) {
                var dbContext = serviceScope.ServiceProvider.GetService<MyDbContext>();
                dbContext.Database.EnsureCreated();

                if(dbContext.Invoices.Count()== 0) {
                    var invoices = new List<Invoice>() {

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

                    foreach(var item in invoices) {
                        dbContext.Invoices.Add(item);
                    }
                    dbContext.SaveChanges();
                }
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
