using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using WebApplication.Services;
using WebApplication.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Controllers {
    public class HomeController : Controller {
        //private readonly IMessageService _messageservice;
        private readonly MyDbContext _datacontext;
        private readonly IMessageService _messageService;

        public HomeController(MyDbContext dataContext, IMessageService messageService) {
            _messageService = messageService;
            _datacontext = dataContext;
        }

        public IActionResult Index() {
            _messageService.Send("Literally Hello World");

            return View();
        }

        public IActionResult Invoices() {
            var model = _datacontext.Invoices.ToList();
            return View(model);
        }

        public async Task<IActionResult> Invoice(int id) {

            var invoice = await _datacontext.Invoices
                .Include(i => i.Lines)
                .FirstOrDefaultAsync(i => i.Id == id);
            if (invoice == null) {
                return null;
            }
            return View(invoice);
        }

        public IActionResult Test(int id) {
            var model = new TestModel();
            model.Id = id;

            return View(model);
        }

        public IActionResult About() {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact() {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
