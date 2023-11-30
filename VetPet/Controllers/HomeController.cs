using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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


        //Constructor
        private readonly VetContext _context;

        public HomeController(VetContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var nombreAdmin = User.Identity.Name;
            ViewBag.nombres = nombreAdmin; 

            var admin = _context.Admins.ToList();
            return View(admin);
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult Admins()
        {
            var admins = _context.Admins.ToList();
            return View(admins);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Admin model)
        {
            if (ModelState.IsValid)
            {

                var admin = new Admin
                {
                    nombres = model.nombres,
                    apePaterno = model.apePaterno,
                    apeMaterno = model.apeMaterno,
                    correo = model.correo,
                    contraseña= model.contraseña
                };

                _context.Admins.Add(admin);
                _context.SaveChanges();

                return RedirectToAction("Admins");
            }

            return View(model);
        }

        [HttpGet]
        // GET: MarcaController/Edit/5
        public IActionResult Edit(int id)
        {
            var admin = _context.Admins.FirstOrDefault(a => a.Id == id);

            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        // POST: MarcaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Admin model)
        {
            if (ModelState.IsValid)
            {
                var admin = _context.Admins.FirstOrDefault(a => a.Id == model.Id);

                if (admin == null)
                {
                    return NotFound();
                }


                admin.nombres = model.nombres;
                admin.apePaterno = model. apePaterno;
                admin.apeMaterno = model.apeMaterno;
                admin.correo = model.correo;
                admin.contraseña = model.contraseña;

                _context.SaveChanges();

                return RedirectToAction("Admins");
            }

            return View(model);
        }
        [HttpGet]
        // GET: MarcaController/Delete/5
        public IActionResult Delete(int id)
        {
            var admin = _context.Admins.FirstOrDefault(a => a.Id == id);

            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        // POST: MarcaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmedDelete(int id)
        {

            var admin = _context.Admins.FirstOrDefault(a => a.Id == id);

            if (admin == null)
            {
                return NotFound();
            }


            _context.Admins.Remove(admin);
            _context.SaveChanges();

            return RedirectToAction("Admins");
        }
    }
}
