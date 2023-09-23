using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VetPet.Database.VetContext;
using VetPet.Models;

namespace VetPet.Controllers
{
    public class HomeController : Controller
    {
        /*private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/

        //Constructor
        private readonly VetContext _context;

        public HomeController(VetContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var admins = _context.Admins.ToList();
            return View(admins);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Admins()
        {
            var admins = _context.Admins.ToList();
            return View(admins);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
